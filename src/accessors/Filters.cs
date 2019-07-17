﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public struct PageFilter
   {
      public int PerPage;
      public int PageNumber;
   }

   public class DiscussionsFilter
   {
      public PageFilter? PageFilter { get; set; }

      public string ToQueryString()
      {
         return "?"
            + (PageFilter.HasValue ? "&page=" + PageFilter?.PageNumber + "&per_page=" + PageFilter?.PerPage : "");
      }
   }

   public class MergeRequestsFilter
   {
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

      public string Labels { get; set; } = String.Empty;
      public WorkInProgressFilter WIP { get; set; } = WorkInProgressFilter.Yes;
      public StateFilter State { get; set; } = StateFilter.Open;
      public PageFilter? PageFilter { get; set; }

      public string ToQueryString()
      {
         return "?scope=all"
         + (WIP != WorkInProgressFilter.All ? ("&wip=" + workInProgressToString(WIP)) : "")
         + (State != StateFilter.All ? ("&state=" + stateFilterToString(State)) : "")
         + (Labels != null && Labels.Length > 0 ? "&labels=" : "")
         + (PageFilter.HasValue ? "&page=" + PageFilter?.PageNumber + "&per_page=" + PageFilter?.PerPage : "");
      }

      private string stateFilterToString(StateFilter state)
      {
         switch (state)
         {
            case StateFilter.All: return "";
            case StateFilter.Closed: return "closed";
            case StateFilter.Merged: return "merged";
            case StateFilter.Open: return "opened"; }
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

   public class ProjectsFilter
   {
      public bool PublicOnly { get; set; } = true;
      public bool WithMergeRequestsEnabled { get; set; } = true;
      public PageFilter? PageFilter { get; set; }

      public string ToQueryString()
      {
         return "?simple=true"
            + (PublicOnly ? "&visibility=public" : "")
            + (WithMergeRequestsEnabled ? "&with_merge_requests_enabled=true" : "")
            + (PageFilter.HasValue ? "&page=" + PageFilter?.PageNumber + "&per_page=" + PageFilter?.PerPage : "");
      }
   }
}
