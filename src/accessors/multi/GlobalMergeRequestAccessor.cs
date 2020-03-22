using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of merge requests
   /// </summary>
   public class GlobalMergeRequestAccessor : BaseMergeRequestAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/merge_requests
      /// </summary>
      internal GlobalMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }
   }
}

