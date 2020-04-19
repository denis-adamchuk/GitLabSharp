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
   /// Internal library representation of a single request to GitLab
   /// </summary>
   internal class GitLabTask : IDisposable
   {
      internal GitLabTask(GitLab gitLab, GitLabClient.Command command)
      {
         GitLab = gitLab;
         MyCommand = command;
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      public void Dispose()
      {
         GitLab.Dispose();
      }

      /// <summary>
      /// Runs a command for GitLab object
      /// </summary>
      async internal Task<object> RunAsync()
      {
         try
         {
            return await MyCommand(GitLab);
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
         GitLab.CancellationTokenSource.Cancel();
      }

      private GitLab GitLab { get; }
      private GitLabClient.Command MyCommand { get; }
   }
}

