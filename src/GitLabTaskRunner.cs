using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using GitLabSharp.Utils;
using GitLabSharp.Accessors;

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
   /// Exception class cases when a group of tasks was cancelled.
   /// </summary>
   public class GitLabTaskRunnerCancelled : Exception { }

   /// <summary>
   /// Runs requests to GitLab API
   /// </summary>
   public class GitLabTaskRunner : IDisposable
   {
      public GitLabTaskRunner(string host, string token)
      {
         _host = host;
         _token = token;
      }

      public void Dispose()
      {
         foreach (GitLabTask task in _runningTasks)
         {
            // Cancelling task here and waiting for OperationCanceledException to dispose the task, see run().
            task.Cancel();
         }
         _runningTasks.Clear();
      }

      /// <summary>
      /// Run client request to GitLab API.
      /// Throws GitLabSharpException when internal error occurred.
      /// Throws GitLabRequestException when GitLab returned an error.
      /// </summary>
      async public Task<object> RunAsync(Func<GitLab, Task<object>> cmd)
      {
         return await run(cmd);
      }

      async private Task<object> run(Func<GitLab, Task<object>> func)
      {
         GitLabTask gitLabTask;
         try
         {
            gitLabTask = new GitLabTask(_host, _token, func);
         }
         catch (ArgumentException ex)
         {
            throw new GitLabSharpException(_host, "Cannot create GitLabTask", ex);
         }

         Debug.Assert(gitLabTask != null);

         _runningTasks.Add(gitLabTask);

         try
         {
            return await gitLabTask.RunAsync();
         }
         catch (OperationCanceledException)
         {
            throw new GitLabTaskRunnerCancelled();
         }
         catch (GitLabRequestException)
         {
            throw;
         }
         finally
         {
            _runningTasks.Remove(gitLabTask);

            gitLabTask.Dispose();
         }
      }

      private readonly string _host;
      private readonly string _token;
      private readonly List<GitLabTask> _runningTasks = new List<GitLabTask>();
   }
}

