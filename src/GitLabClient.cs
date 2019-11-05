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
   public class GitLabClient
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
         issueCancel();
         return await run(cmd);
      }

      /// <summary>
      /// Cancels currently running task
      /// </summary>
      async public Task CancelAsync()
      {
         issueCancel();

         // The worst but the simplest way to wait, later change to TaskCompletionSource
         while (RunningTasks.Count > 0)
         {
            await Task.Delay(50);
         }
      }

      private void issueCancel()
      {
         foreach (GitLabTask task in RunningTasks)
         {
            task.Cancel();
         }
      }

      async private Task<object> run(Command cmd)
      {
         GitLabTask gitLabTask;
         try
         {
            gitLabTask = new GitLabTask(new GitLab(Host, Token), cmd);
         }
         catch (ArgumentException ex)
         {
            throw new GitLabSharpException(Host, "Cannot create GitLabTask", ex);
         }

         Debug.Assert(gitLabTask != null);

         RunningTasks.Add(gitLabTask);

         try
         {
            return await gitLabTask.RunAsync();
         }
         catch (OperationCanceledException)
         {
            throw new GitLabClientCancelled();
         }
         catch (GitLabSharp.Accessors.GitLabRequestException)
         {
            throw;
         }
         finally
         {
            RunningTasks.Remove(gitLabTask);

            gitLabTask.Dispose();
         }
      }

      private string Host { get; }
      private string Token { get; }
      private readonly List<GitLabTask> RunningTasks = new List<GitLabTask>();
   }
}

