using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to GitLab API requests
   /// </summary>
   public class RootAccessor : BaseAccessor
   {
      internal RootAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Get access to information about current user
      /// </summary>
      public SingleUserAccessor CurrentUser()
      {
         return new SingleUserAccessor(HttpClient, BaseUrl + "/user");
      }

      /// <summary>
      /// Get access to list of projects hosted at this server
      /// </summary>
      /// <returns></returns>
      public ProjectsAccessor Projects()
      {
         return new ProjectsAccessor(HttpClient, BaseUrl + "/projects");
      }
   }
}
