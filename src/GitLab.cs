using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class GitLab
   {
      /// <summary>
      /// Provides access to GitLab API requests
      /// </summary>
      public GitLab(string host, string token)
      {
         Client = new HttpClient(host, token);
         BaseUrl = host + "/api/" + "v4";
      }

      /// <summary>
      /// Get access to information about current user
      /// </summary>
      public SingleUserAccessor CurrentUser => new SingleUserAccessor(Client, BaseUrl + "/user");

      /// <summary>
      /// Get access to list of projects hosted at this server
      /// </summary>
      /// <returns></returns>
      public ProjectsAccessor Projects => new ProjectsAccessor(Client, BaseUrl + "/projects");

      private HttpClient Client;
      private string BaseUrl;
   }
}
