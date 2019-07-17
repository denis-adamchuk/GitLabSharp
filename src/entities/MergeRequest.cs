using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr
   /// </summary>
   public class MergeRequest
   {
      public int Id;
      public string Title;
      public string Description;
      public string Source_Branch;
      public string Target_Branch;
      public string State;
      public List<string> Labels;
      public string Web_Url;
      public bool Work_In_Progress;
      public User Author;
      public DiffRefs Diff_Refs;
   }
}
