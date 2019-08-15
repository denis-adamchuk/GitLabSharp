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
         cancel();
         return await complete(cmd);
      }

      /// <summary>
      /// Cancels currently running task
      /// </summary>
      async public Task CancelAsync()
      {
         cancel();
         await Semaphore.WaitAsync();
         Semaphore.Release();
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      public void Dispose()
      {
         Semaphore.Dispose();
      }

      private void cancel()
      {
         if (CurrentTask == null)
         {
            return;
         }

         Debug.WriteLine("Issuing task cancellation" + " id #" + CurrentTask.Id);
         CurrentTask.Cancel();
      }

      async private Task<object> complete(Command cmd)
      {
         Debug.WriteLine("Waiting for a semaphore before start a new task");
         await Semaphore.WaitAsync();

         Debug.WriteLine("Task cancelled and semaphore released, ready to start a new task");
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

         Debug.WriteLine("Running task" + " id #" + CurrentTask.Id);
         try
         {
            object obj = await CurrentTask.RunAsync();
            Debug.WriteLine("Current task completed" + " id #" + CurrentTask.Id);
            return obj;
         }
         catch (OperationCanceledException)
         {
            Debug.WriteLine("Current task cancelled" + " id #" + CurrentTask.Id);
            throw new GitLabClientCancelled();
         }
         catch (GitLabSharp.Accessors.GitLabRequestException)
         {
            Debug.WriteLine("Exception occurred in the current task" + " id #" + CurrentTask.Id);
            throw;
         }
         finally
         {
            Debug.WriteLine("Disposing current task" + " id #" + CurrentTask.Id);
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

