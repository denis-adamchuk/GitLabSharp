using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mrHelper.Client
{
   /// <summary>
   /// Internal library representation of a single request to GitLab
   /// </summary>
   internal class GitLabTask : IDisposable
   {
      internal GitLabTask(GitLab gitLab, Command command)
      {
         GitLab = gitLab;
         Command = command;
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      internal void Dispose()
      {
         Debug.WriteLine("A task is being disposed");
         GitLab.Dispose();
      }

      internal delegate object Command(GitLab gitLab);

      /// <summary>
      /// Runs a command for GitLab object
      /// </summary>
      async internal Task<object> RunAsync()
      {
         await Command(GitLab);
      }

      /// <summary>
      /// Cancels currently executing command at the GitLab object 
      /// </summary>
      void internal Cancel()
      {
         Debug.WriteLine("A task is going to be cancelled");
         GitLab.CurrentCancellationTokenSource.Cancel();
      }

      private GitLab GitLab { get; }
      private Command Command { get; }
   }
}

