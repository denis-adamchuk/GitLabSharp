using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-a-single-mr-diff-version
   /// </summary>
   public class Version
   {
      public int Id;
      public string Base_Commit_SHA;
      public string Head_Commit_SHA;
      public string Start_Commit_SHA;
      public DateTime Created_At;
   }
}

