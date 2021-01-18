using System;
using System.Threading.Tasks;
using GitLabSharp.Accessors;

namespace GitLabSharp
{
   /// <summary>
   /// Internal library representation of a single request to GitLab
   /// </summary>
   internal class GitLabTask : IDisposable
   {
      internal GitLabTask(string host, string token, Func<GitLab, Task<object>> func)
      {
         _gitlab = new GitLab(host, token);
         _func = func;
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      public void Dispose()
      {
         _gitlab?.Dispose();
         _gitlab = null;
      }

      /// <summary>
      /// Runs a command for GitLab object
      /// </summary>
      async internal Task<object> RunAsync()
      {
         try
         {
            return await _func(_gitlab);
         }
         catch (OperationCanceledException)
         {
            throw;
         }
      }

      /// <summary>
      /// Cancels currently executing command at the GitLab object
      /// </summary>
      internal void Cancel()
      {
         _gitlab?.Cancel();
      }

      private GitLab _gitlab;

      private Func<GitLab, Task<object>> _func { get; }
   }
}

