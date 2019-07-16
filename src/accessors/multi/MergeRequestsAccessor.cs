using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a list of merge requests
   /// </summary>
   public class MergeRequestsAccessor : BaseLoader<List<MergeRequest>>
   {
      internal MergeRequestsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of merge requests from Server and de-serialize it
      /// </summary>
      public List<MergeRequest> Details(MergeRequestsFilter filter)
      {
         return DoLoad(BaseUrl + filter.ToQueryString());
      }

      /// <summary>
      /// Get access to a single merge request by Id
      /// </summary>
      public SingleMergeRequestAccessor Get(int mergeRequestId)
      {
         return new SingleMergeRequestAccessor(HttpClient, BaseUrl +  "/" + mergeRequestId.ToString());
      }
   }
}
