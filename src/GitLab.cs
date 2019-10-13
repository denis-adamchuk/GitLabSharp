using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GitLabSharp.Accessors;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to GitLab API requests
   /// </summary>
   public class GitLab : IDisposable
   {
      /// <summary>
      /// Throws ArgumentException when host name is invalid
      /// </summary>
      internal GitLab(string host, string token)
      {
         CancellationTokenSource = new CancellationTokenSource();
         Client = new HttpClient(host, token, CancellationTokenSource);
         BaseUrl = host + "/api/" + "v4";
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      public void Dispose()
      {
         CancellationTokenSource.Dispose();
         Client.Dispose();
      }

      /// <summary>
      /// Get access to information about current user
      /// </summary>
      public SingleUserAccessor CurrentUser => new SingleUserAccessor(Client, BaseUrl + "/user");

      /// <summary>
      /// Get access to list of projects hosted at this server
      /// </summary>
      /// <returns></returns>
      public ProjectAccessor Projects => new ProjectAccessor(Client, BaseUrl + "/projects");

      internal CancellationTokenSource CancellationTokenSource { get; }

      private HttpClient Client { get; }
      private string BaseUrl { get; }
   }
}

