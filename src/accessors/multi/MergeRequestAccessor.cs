﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of project merge requests
   /// </summary>
   public class MergeRequestAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/4/merge_requests
      /// </summary>
      internal MergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
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

      /// <summary>
      /// Get access to a single merge request by IId
      /// </summary>
      public SingleMergeRequestAccessor Get(int mergeRequestIId)
      {
         if (mergeRequestIId == 0)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by zero merge request IId", null);
         }
         return new SingleMergeRequestAccessor(Client, BaseUrl +  "/" + mergeRequestIId.ToString());
      }
   }
}
