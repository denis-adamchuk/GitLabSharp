using System;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr-commits
   /// </summary>
   public struct Commit
   {
      public string Id;
      public DateTime Created_At;
   }
}

