using System;
using System.Threading;
using GitLabSharp.Accessors;

namespace GitLabSharp.Accessors
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
         CancellationTokenSource = null;

         Client.Dispose();
         Client = null;
      }

      internal void Cancel()
      {
         CancellationTokenSource?.Cancel();
      }

      /// <summary>
      /// Host passed to constructor
      /// </summary>
      public string Host => Client?.Host;

      /// <summary>
      /// Get access to information about GitLab version
      /// </summary>
      public SingleGitLabVersionAccessor Version => new SingleGitLabVersionAccessor(Client, BaseUrl + "/version");

      /// <summary>
      /// Get access to information about current user
      /// </summary>
      public SingleUserAccessor CurrentUser => new SingleUserAccessor(Client, BaseUrl + "/user");

      /// <summary>
      /// Get access to list of users at this server
      /// </summary>
      public UserAccessor Users => new UserAccessor(Client, BaseUrl + "/users");

      /// <summary>
      /// Get access to list of projects hosted at this server
      /// </summary>
      public ProjectAccessor Projects => new ProjectAccessor(Client, BaseUrl + "/projects");

      /// <summary>
      /// Get access to list of merge requests stored at this server
      /// </summary>
      public GlobalMergeRequestAccessor MergeRequests =>
         new GlobalMergeRequestAccessor(Client, BaseUrl + "/merge_requests");

      private CancellationTokenSource CancellationTokenSource;

      private HttpClient Client;

      private string BaseUrl { get; }
   }
}

