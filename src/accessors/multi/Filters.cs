using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public struct Filter
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

      string Labels;
      StateFilter State;
      WorkInProgressFilter WIP;

      string ToQueryString()
      {
         throw new NotImplementedException();
      }
   }
}
