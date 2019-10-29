using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Accessors
{
   public struct PageFilter
   {
      public int PerPage;
      public int PageNumber;

      public string ToQueryString()
      {
         return "page=" + PageNumber.ToString() + "&per_page=" + PerPage.ToString();
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
      public bool SimpleView { get; set; } = false;

      public string ToQueryString()
      {
         return "scope=all"
         + (SimpleView ? ("&view=simple") : "")
         + (WIP != WorkInProgressFilter.All ? ("&wip=" + workInProgressToString(WIP)) : "")
         + (State != StateFilter.All ? ("&state=" + stateFilterToString(State)) : "")
         + (Labels != null && Labels.Length > 0 ? "&labels=" : "");
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

      public string ToQueryString()
      {
         return "simple=true"
            + (PublicOnly ? "&visibility=public" : "")
            + (WithMergeRequestsEnabled ? "&with_merge_requests_enabled=true" : "");
      }
   }

   public class SortFilter
   {
      public bool Ascending = false;
      public string OrderBy = String.Empty;

      public string ToQueryString()
      {
         return "sort=" + (Ascending ? "asc" : "desc")
              + (OrderBy == String.Empty ? "" : "&order_by=" + OrderBy);
      }
   }
}

