using System;
using System.Collections.Generic;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr-commits
   /// </summary>
   public struct Commit
   {
      public string Id;
      public DateTime Created_At;
      public string Title;
      public string Message;
      public IEnumerable<string> Parent_Ids;
   }
}

