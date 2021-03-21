using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of projects
   /// </summary>
   public class ProjectAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects
      /// </summary>
      internal ProjectAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of projects from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Project>> LoadAllTaskAsync(ProjectsFilter filter)
      {
         return GetAllTaskAsync<Project>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Get access to a single project
      /// </summary>
      public SingleProjectAccessor Get(string projectId)
      {
         if (projectId == null)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by null project id", null);
         }
         return new SingleProjectAccessor(Client, BaseUrl + "/" + Uri.EscapeDataString(projectId));
      }
   }
}
