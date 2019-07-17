using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a list of projects
   /// </summary>
   public class ProjectsAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects
      /// </summary>
      internal ProjectsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Get number of projects taking into account the filter
      /// </summary>
      public int Count(ProjectsFilter filter)
      {
         return Count(BaseUrl + filter.ToQueryString());
      }

      /// <summary>
      /// Load full list of projects from Server and de-serialize it
      /// </summary>
      public List<Project> Load(ProjectsFilter filter, PageFilter? pageFilter)
      {
         return Get<List<Project>>(BaseUrl + filter.ToQueryString() + pageFilter?.ToQueryString(false));
      }

      /// <summary>
      /// Get access to a single project
      /// </summary>
      public SingleProjectAccessor Get(string projectId)
      {
         return new SingleProjectAccessor(Client, BaseUrl + "/" + WebUtility.UrlEncode(projectId));
      }
   }
}
