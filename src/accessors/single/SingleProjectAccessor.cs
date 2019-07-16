using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class SingleProjectAccessor : BaseLoader<Project>
   {
      internal SingleProjectAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public MergeRequestsAccessor MergeRequests()
      {
         return new MergeRequestsAccessor(_httpClient, _baseUrl + "/merge_requests");
      }
   }
}
