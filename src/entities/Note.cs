using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/notes.html#get-single-merge-request-note
   /// </summary>
   public struct Note
   {
      public int Id;
      public string Body;
      public DateTime Created_At;
      public User Author;
      public bool System;
   }
}
