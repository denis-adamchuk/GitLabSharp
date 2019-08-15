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
      internal static int NextId = 0;
      internal int Id = 0;

      internal GitLabTask(GitLab gitLab, GitLabClient.Command command)
      {
         GitLab = gitLab;
         MyCommand = command;
         NextId++;
         Id = NextId;
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      public void Dispose()
      {
         Debug.WriteLine("A task is being disposed");
         GitLab.Dispose();
      }

      /// <summary>
      /// Runs a command for GitLab object
      /// </summary>
      internal Task<object> RunAsync()
      {
         return MyCommand(GitLab);
      }

      /// <summary>
      /// Cancels currently executing command at the GitLab object 
      /// </summary>
      internal void Cancel()
      {
         Debug.WriteLine("A task is going to be cancelled");
         GitLab.CancellationTokenSource.Cancel();
      }

      private GitLab GitLab { get; }
      private GitLabClient.Command MyCommand { get; }
   }
}

