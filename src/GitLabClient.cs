using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GitLabSharp
{
   /// <summary>
   /// Runs requests to GitLab API
   /// </summary>
   public class GitLabClient : IDisposable
   {
      public GitLabClient(string host, string token)
      {
         Host = host;
         Token = token;
      }

      public delegate Task<object> Command(GitLab gitLab);

      /// <summary>
      /// Run client request to GitLab API.
      /// Cancels currently running task (if it exists).
      /// </summary>
      async public Task<object> RunAsync(Command cmd)
      {
         await cancel();
         return complete(cmd);
      }

      /// <summary>
      /// Cancels currently running task
      /// </summary>
      async public Task CancelAsync()
      {
         await cancel();
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      public void Dispose()
      {
         Task.Run(async () => await cancel()).Wait();
      }

      async private Task cancel()
      {
         if (CurrentTask == null)
         {
            return;
         }

         Debug.WriteLine("Issueing task cancellation");
         CurrentTask.Cancel();

         Debug.WriteLine("Waiting for current task cancellation");
         await Semaphore.WaitAsync();
      }

      async private Task<object> complete(Command cmd)
      {
         Debug.Assert(CurrentTask == null);
         var gitLabTask = new GitLabTask(new GitLab(Host, Token), cmd);

         Debug.WriteLine("Waiting for completion of the current task");
         try
         {
            object obj = await CurrentTask.RunAsync();
            Debug.WriteLine("Current task completed");
            return obj;
         }
         catch (OperationCanceledException)
         {
            Debug.WriteLine("Current task cancelled");
         }
         catch (GitLabSharp.Accessors.GitLabRequestException)
         {
            Debug.WriteLine("Exception occurred in the current task");
            throw;
         }
         finally
         {
            Debug.WriteLine("Disposing current task");
            CurrentTask.Dispose();
            CurrentTask = null;
            Semaphore.Release();
         }
         return null;
      }

      private string Host { get; }
      private string Token { get; }
      private GitLabTask CurrentTask = null;
      private SemaphoreSlim Semaphore = new SemaphoreSlim(1);
   }
}

