using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public struct MergeRequestsFilter
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

      public string Labels;
      public StateFilter State;
      public WorkInProgressFilter WIP;

      public string ToQueryString()
      {
         return "?scope=all"
         + (WIP != WorkInProgressFilter.All ? ("&wip=" + workInProgressToString(WIP)) : "")
         + (State != StateFilter.All ? ("&state=" + stateFilterToString(State)) : "")
         + (Labels.Length > 0 ? "&labels=" : "");
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
}
