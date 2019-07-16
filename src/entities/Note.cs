using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/notes.html#get-single-merge-request-note
   /// </summary>
   public class Note
   {
      public int Id;
      public string Body;
      public System.DateTime CreatedAt;
      public User Author;
      public bool System;
   }

   /// <summary>
   /// Used to modify notes
   /// Warning: 'Resolved' field makes sense for notes that belong to discussions only
   /// https://docs.gitlab.com/ce/api/discussions.html#modify-an-existing-merge-request-thread-note
   /// https://docs.gitlab.com/ce/api/notes.html#modify-existing-merge-request-note 
   /// </summary>
   public class NoteModificationParameters
   {
      public enum ModificationType
      {
         Body,
         Resolved
      }

      public ModificationType Type;
      public string Body;
      public bool Resolved;

      public string ToQueryString()
      {
         switch (Type)
         {
            case NoteModificationParameters.ModificationType.Body:
               return "?body=" + WebUtility.UrlEncode(Body);
            case NoteModificationParameters.ModificationType.Resolved:
               return "?resolved=" + Resolved.ToString();
         }
         return "";
      }
   }
}
