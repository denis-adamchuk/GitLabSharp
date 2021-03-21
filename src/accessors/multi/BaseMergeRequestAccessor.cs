using GitLabSharp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of project merge requests
   /// </summary>
   public class BaseMergeRequestAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// See baseUrl examples in derived classes
      /// </summary>
      internal BaseMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of merge requests from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<MergeRequest>> LoadTaskAsync(MergeRequestsFilter filter, PageFilter pageFilter)
      {
         return GetTaskAsync<IEnumerable<MergeRequest>>(BaseUrl +
            "?" + filter.ToQueryString() + "&" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of merge requests from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<MergeRequest>> LoadAllTaskAsync(MergeRequestsFilter filter)
      {
         return GetAllTaskAsync<MergeRequest>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }
   }
}

