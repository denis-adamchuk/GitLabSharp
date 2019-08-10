using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a single project
   /// </summary>
   public class SingleProjectAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/1
      /// </summary>
      internal SingleProjectAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about project from Server and de-serializes it
      /// </summary>
      public Project Load()
      {
         return Get<Project>(BaseUrl);
      }

      /// <summary>
      /// Get access to a list of merge requests of this project
      /// </summary>
      public MergeRequestAccessor MergeRequests => new MergeRequestAccessor(Client, BaseUrl + "/merge_requests");
   }
}
