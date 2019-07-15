using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class Discussion
   {
      public Discussion(Dictionary<string, object> json)
      {
         throw new NotImplementedException();
      }

      public string Id;
      public List<DiscussionNote> Notes;
      public bool IndividualNote;
   } 
}
