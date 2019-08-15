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
   /// Exception class for non-specific issues.
   /// </summary>
   public class GitLabSharpException : Exception
   {
      internal GitLabSharpException(string url, string error, Exception exception = null)
         : base(String.Format("Error occurred with URL \"{0}\": {1}", url, error))
      {
         InternalException = exception;
      }

      public Exception InternalException { get; }
   }

   /// <summary>
   /// Exception class cases when operation was cancelled by a subsequent request.
   /// </summary>
   public class GitLabClientCancelled : Exception { }

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
      /// Throws GitLabSharpException when internal error occurred.
      /// Throws GitLabRequestException when GitLab returned an error.
      /// </summary>
      async public Task<object> RunAsync(Command cmd)
      {
         await cancel();
         return await complete(cmd);
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

         Debug.WriteLine("Issuing task cancellation");
         CurrentTask.Cancel();

         Debug.WriteLine("Waiting for current task cancellation (semaphore)");
         await Semaphore.WaitAsync();

         CurrentTask.Dispose();
         CurrentTask = null;
      }

      async private Task<object> complete(Command cmd)
      {
         Debug.Assert(CurrentTask == null);

         try
         {
            CurrentTask = new GitLabTask(new GitLab(Host, Token), cmd);
         }
         catch (ArgumentException ex)
         {
            Debug.WriteLine("Cannot create GitLabTask");
            throw new GitLabSharpException(Host, "Cannot create GitLabTask", ex);
         }

         Debug.Assert(CurrentTask != null);

         Debug.WriteLine("Waiting for semaphore");
         Semaphore.Wait();

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
            throw new GitLabClientCancelled();
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

            Debug.WriteLine("Releasing semaphore");
            Semaphore.Release();
         }
      }

      private string Host { get; }
      private string Token { get; }
      private GitLabTask CurrentTask = null;
      private SemaphoreSlim Semaphore = new SemaphoreSlim(1);
   }
}

