using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-a-single-mr-diff-version
   /// </summary>
   public struct Diff
   {
      public string Old_Path;
      public string New_Path;
      public bool New_File;
      public bool Renamed_File;
      public bool Deleted_File;
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-mr-diff-versions
   /// </summary>
   public struct Version
   {
      public int Id;
      public string Base_Commit_SHA;
      public string Head_Commit_SHA;
      public string Start_Commit_SHA;
      public DateTime Created_At;
      public IEnumerable<Diff> Diffs;
   }
}

