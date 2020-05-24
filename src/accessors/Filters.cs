using System;
using System.Collections.Generic;
using System.Net;

namespace GitLabSharp.Accessors
{
   public struct PageFilter
   {
      public PageFilter(int perPage, int pageNumber)
      {
         PerPage = perPage;
         PageNumber = pageNumber;
      }

      public int PerPage { get; }
      public int PageNumber { get; }

      public string ToQueryString()
      {
         return "page=" + PageNumber.ToString() + "&per_page=" + PerPage.ToString();
      }
   }

   public struct MergeRequestsFilter
   {
      public MergeRequestsFilter(string labels, WorkInProgressFilter wip, StateFilter state,
         bool simpleView, string search, string targetBranch, IEnumerable<int> iids, string authorUsername,
         int? assigneeId)
      {
         Labels = labels;
         WIP = wip;
         State = state;
         SimpleView = simpleView;
         Search = search;
         TargetBranch = targetBranch;
         IIds = iids;
         AuthorUsername = authorUsername;
         AssigneeId = assigneeId;
      }

      public enum StateFilter
      {
         Open,
         Closed,
         Merged,
         All
      }

      public enum WorkInProgressFilter
      {
         Yes,
         No,
         All
      }

      public string Labels { get; }
      public WorkInProgressFilter WIP { get; }
      public StateFilter State { get; }
      public bool SimpleView { get; }
      public string Search { get; }
      public string TargetBranch { get; }
      public IEnumerable<int> IIds { get; }
      public string AuthorUsername { get; }
      public int? AssigneeId { get; }

      public string ToQueryString()
      {
         return "scope=all"
         + (SimpleView ? ("&view=simple") : "")
         + (WIP != WorkInProgressFilter.All ? ("&wip=" + workInProgressToString(WIP)) : "")
         + (State != StateFilter.All ? ("&state=" + stateFilterToString(State)) : "")
         + (String.IsNullOrWhiteSpace(Labels) ? "" : "&labels=" + WebUtility.UrlEncode(Labels))
         + (String.IsNullOrWhiteSpace(AuthorUsername) ? "" : "&author_username=" + WebUtility.UrlEncode(AuthorUsername))
         + (AssigneeId == null ? "" : "&assignee_id=" + AssigneeId.Value.ToString())
         + (IIds != null ? String.Join("iids[]=", IIds) : "")
         + (String.IsNullOrWhiteSpace(TargetBranch) ? "" : "&target_branch=" + WebUtility.UrlEncode(TargetBranch))
         + (String.IsNullOrWhiteSpace(Search) ? "" : "&search=" + WebUtility.UrlEncode(Search));
      }

      private string stateFilterToString(StateFilter state)
      {
         switch (state)
         {
            case StateFilter.All: return "";
            case StateFilter.Closed: return "closed";
            case StateFilter.Merged: return "merged";
            case StateFilter.Open: return "opened";
         }
         return "";
      }

      private string workInProgressToString(WorkInProgressFilter wip)
      {
         switch (wip)
         {
            case WorkInProgressFilter.All: return "";
            case WorkInProgressFilter.No: return "no";
            case WorkInProgressFilter.Yes: return "yes";
         }
         return "";
      }
   }

   public struct ProjectsFilter
   {
      public ProjectsFilter(bool publicOnly, bool withMergeRequestsEnabled)
      {
         PublicOnly = publicOnly;
         WithMergeRequestsEnabled = withMergeRequestsEnabled;
      }

      public bool PublicOnly { get; }
      public bool WithMergeRequestsEnabled { get; }

      public string ToQueryString()
      {
         return "simple=true"
            + (PublicOnly ? "&visibility=public" : "")
            + (WithMergeRequestsEnabled ? "&with_merge_requests_enabled=true" : "");
      }
   }

   public struct SortFilter
   {
      public SortFilter(bool ascending, string orderBy)
      {
         Ascending = ascending;
         OrderBy = orderBy;
      }

      public bool Ascending { get; }
      public string OrderBy { get; }

      public string ToQueryString()
      {
         return "sort=" + (Ascending ? "asc" : "desc")
              + (String.IsNullOrWhiteSpace(OrderBy) ? "" : "&order_by=" + OrderBy);
      }
   }
}

