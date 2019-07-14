using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Note
   {
      public Note(MergeRequest mergeRequest)
      {
      }

      public string Body
      {
         get { return ""; }
         set { }
      }

      public bool Resolved
      {
         get { return false; }
         set { }
      }
   }
}
