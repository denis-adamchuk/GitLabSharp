using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of merge requests
   /// </summary>
   public class GlobalMergeRequestAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/merge_requests
      /// </summary>
      internal GlobalMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load list of merge requests from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<MergeRequest>> LoadTaskAsync(GlobalMergeRequestsFilter filter,
         PageFilter pageFilter, SortFilter sortFilter)
      {
         return GetTaskAsync<IEnumerable<MergeRequest>>(BaseUrl +
            "?" + filter.ToQueryString() + "&" + pageFilter.ToQueryString() + "&" + sortFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of merge requests from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<MergeRequest>> LoadAllTaskAsync(GlobalMergeRequestsFilter filter)
      {
         return GetAllTaskAsync<MergeRequest>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Get number of merge requests taking into account the filter
      /// </summary>
      public int Count(GlobalMergeRequestsFilter filter)
      {
         return Count(BaseUrl + "?" + filter.ToQueryString());
      }
   }
}
