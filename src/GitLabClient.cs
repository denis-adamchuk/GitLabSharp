using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using GitLabSharp.Utils;

namespace GitLabSharp
{
   /// <summary>
   /// Exception class for non-specific issues.
   /// </summary>
   public class GitLabSharpException : ExceptionEx
   {
      internal GitLabSharpException(string url, string error, Exception innerException)
         : base(String.Format("Internal error with URL \"{0}\": {1}", url, error), innerException)
      {
      }
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
      /// Throws GitLabSharpException when internal error occurred.
      /// Throws GitLabRequestException when GitLab returned an error.
      /// </summary>
      async public Task<object> RunAsync(Command cmd)
      {
         return await run(cmd);
      }

      /// <summary>
      /// Cancels currently running tasks
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

      /// <summary>
      /// Cancels currently running tasks
      /// </summary>
      public void Cancel()
      {
         issueCancel();
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
            gitLabTask = new GitLabTask(Host, Token, cmd);
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

