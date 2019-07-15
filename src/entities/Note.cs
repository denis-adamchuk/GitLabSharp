using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class Note
   {
      public Note(Dictionary<string, object> json)
      {
         throw new NotImplementedException();
      }

      public int Id;
      public string Body;
      public System.DateTime CreatedAt;
      public User Author;
      public bool System;
   }
}
