using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class MergeRequestsAccessor : BaseLoader<List<MergeRequest>>
   {
      internal MergeRequestsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

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
      }

      public SingleMergeRequestAccessor Single(int mergeRequestId)
      {
         return new SingleMergeRequestAccessor(_httpClient, "/" + mergeRequestId.ToString());
      }
   }
}
