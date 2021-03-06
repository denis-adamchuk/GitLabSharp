﻿using System;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single merge request instance
   /// </summary>
   public class SingleMergeRequestAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/4/merge_requests/1
      /// </summary>
      internal SingleMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this merge request from Server and de-serialize it
      /// </summary>
      public Task<MergeRequest> LoadTaskAsync(bool? includeRebaseInProgress = null)
      {
         string url = BaseUrl;
         if (includeRebaseInProgress.HasValue)
         {
            url += String.Format("?include_rebase_in_progress={0}", includeRebaseInProgress.Value.ToString().ToLower());
         }
         return GetTaskAsync<MergeRequest>(url);
      }

      /// <summary>
      /// Get access to a list of versions of this merge request
      /// </summary>
      public VersionAccessor Versions => new VersionAccessor(Client, BaseUrl + "/versions");

      /// <summary>
      /// Get access to a list of commits of this merge request
      /// </summary>
      public CommitAccessor Commits => new CommitAccessor(Client, BaseUrl + "/commits");

      /// <summary>
      /// Get access to a list of discussions of this merge request
      /// </summary>
      public DiscussionAccessor Discussions => new DiscussionAccessor(Client, BaseUrl + "/discussions");

      /// <summary>
      /// Get access to a list of notes of this merge request
      /// </summary>
      public NoteAccessor Notes => new NoteAccessor(Client, BaseUrl + "/notes");

      /// <summary>
      /// Add spent time to the merge request of this merge request
      /// </summary>
      public Task<SpentTime> AddSpentTimeAsync(AddSpentTimeParameters parameters)
      {
         return PostTaskAsync<SpentTime>(BaseUrl + "/add_spent_time?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Update merge request
      /// </summary>
      public Task<MergeRequest> UpdateMergeRequestTaskAsync(UpdateMergeRequestParameters parameters)
      {
         return PutTaskAsync<MergeRequest>(BaseUrl + parameters.ToQueryString());
      }

      /// <summary>
      /// Rebase merge request
      /// </summary>
      public Task<MergeRequestRebaseResponse> RebaseMergeRequestTaskAsync(bool? skipCI = null)
      {
         string url = BaseUrl + "/rebase";
         if (skipCI.HasValue)
         {
            url += String.Format("?skip_ci={0}", skipCI.Value.ToString());
         }
         return PutTaskAsync<MergeRequestRebaseResponse>(url);
      }

      /// <summary>
      /// Accept merge request (Merge)
      /// </summary>
      public Task<MergeRequest> AcceptMergeRequestTaskAsync(AcceptMergeRequestParameters parameters)
      {
         return PutTaskAsync<MergeRequest>(BaseUrl + "/merge" + parameters.ToQueryString());
      }

      /// <summary>
      /// Load merge request approval configuration
      /// </summary>
      public Task<MergeRequestApprovalConfiguration> GetApprovalConfigurationTaskAsync()
      {
         return GetTaskAsync<MergeRequestApprovalConfiguration>(BaseUrl + "/approvals");
      }

      /// <summary>
      /// Approve merge request
      /// </summary>
      public Task<MergeRequestApprovalConfiguration> ApproveTaskAsync()
      {
         return PostTaskAsync<MergeRequestApprovalConfiguration>(BaseUrl + "/approve");
      }

      /// <summary>
      /// Unapprove merge request
      /// </summary>
      public Task<MergeRequestApprovalConfiguration> UnapproveTaskAsync()
      {
         return PostTaskAsync<MergeRequestApprovalConfiguration>(BaseUrl + "/unapprove");
      }
   }
}

