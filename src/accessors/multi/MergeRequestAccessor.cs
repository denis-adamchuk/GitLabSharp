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
   /// Provides access to a list of merge requests
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
      public List<MergeRequest> Load(MergeRequestsFilter filter, PageFilter pageFilter)
      {
         return Get<List<MergeRequest>>(BaseUrl + "?" + filter.ToQueryString() + "&" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it (async)
      /// </summary>
      public List<MergeRequest> LoadAll(MergeRequestsFilter filter)
      {
         return GetAll<List<MergeRequest>, MergeRequest>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it (async)
      /// </summary>
      public Task<List<MergeRequest>> LoadAllTaskAsync(MergeRequestsFilter filter)
      {
         return GetAllTaskAsync<List<MergeRequest>, MergeRequest>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Get number of merge requests taking into account the filter
      /// </summary>
      public int Count(MergeRequestsFilter filter)
      {
         return Count(BaseUrl + "?" + filter.ToQueryString());
      }

      /// <summary>
      /// Get access to a single merge request by Id
      /// </summary>
      public SingleMergeRequestAccessor Get(int mergeRequestId)
      {
         if (mergeRequestId == 0)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by zero merge request Id");
         }
         return new SingleMergeRequestAccessor(Client, BaseUrl +  "/" + mergeRequestId.ToString());
      }
   }
}
