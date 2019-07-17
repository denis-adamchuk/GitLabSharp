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
   public class SingleProjectAccessor : BaseAccessor<Project>
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/1
      /// </summary>
      internal SingleProjectAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Get access to a list of merge requests of this project
      /// </summary>
      public MergeRequestsAccessor MergeRequests()
      {
         return new MergeRequestsAccessor(HttpClient, BaseUrl + "/merge_requests");
      }
   }
}
