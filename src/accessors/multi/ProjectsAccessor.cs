using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a list of projects
   /// </summary>
   public class ProjectsAccessor : BaseAccessor<List<Project>>
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects
      /// </summary>
      internal ProjectsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of projects from Server and de-serialize it
      /// </summary>
      public List<Project> Details()
      {
         return DoLoad(BaseUrl);
      }

      /// <summary>
      /// Get access to a single project
      /// </summary>
      public SingleProjectAccessor Single(string projectId)
      {
         return new SingleProjectAccessor(HttpClient, BaseUrl + "/" + projectId);
      }
   }
}
