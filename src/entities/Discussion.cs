using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class Discussion
   {
      public string Id;
      public List<DiscussionNote> Notes;
      public bool IndividualNote;
   } 
}
