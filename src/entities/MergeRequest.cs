using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class MergeRequest
   {
      public enum State
      {
         Opened,
         Closed,
         Locked,
         Merged
      }

      public int Id;
      public string Title;
      public string Description;
      public string SourceBranch;
      public string TargetBranch;
      public State MRState;
      public List<string> Labels;
      public string WebUrl;
      public bool WorkInProgress;
      public User Author;
      public DiffRefs Refs;
   }
}
