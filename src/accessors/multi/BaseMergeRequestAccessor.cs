using GitLabSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
      /// Load a single page from a full list of merge requests from Server and de-serialize it
      /// </summary>
      public IEnumerable<MergeRequest> Load(MergeRequestsFilter filter, PageFilter pageFilter)
      {
         return Get<IEnumerable<MergeRequest>>(BaseUrl + "?" + filter.ToQueryString() + "&" + pageFilter.ToQueryString());
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
      public IEnumerable<MergeRequest> LoadAll(MergeRequestsFilter filter)
      {
         return GetAll<MergeRequest>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Load full list of merge requests from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<MergeRequest>> LoadAllTaskAsync(MergeRequestsFilter filter)
      {
         return GetAllTaskAsync<MergeRequest>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Get number of merge requests taking into account the filter
      /// </summary>
      public int Count(MergeRequestsFilter filter)
      {
         return Count(BaseUrl + "?" + filter.ToQueryString());
      }
   }
}

