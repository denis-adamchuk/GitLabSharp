using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public enum DiscussionNoteType
   {
      Default,
      DiffNote,
      DiscussionNote
   }

   public struct DiscussionNote
   {
      public int Id;
      public string Body;
      public System.DateTime CreatedAt;
      public User Author;
      public DiscussionNoteType Type;
      public bool System;
      public bool Resolvable;
      public bool? Resolved;
      public Position? Position; // notes with type DiffNote must have it (others must not)
   }
}
