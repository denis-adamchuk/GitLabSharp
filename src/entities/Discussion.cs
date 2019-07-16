using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/discussions.html#get-single-merge-request-discussion-item
   /// </summary>
   public class Discussion
   {
      public string Id;
      public List<DiscussionNote> Notes;
      public bool IndividualNote;
   }

   /// <summary>
   /// Type of a note that belongs to a discussion
   /// </summary>
   public enum DiscussionNoteType
   {
      Default,
      DiffNote,
      DiscussionNote
   }

   /// <summary>
   /// Description of a note that belongs to a discussion
   /// https://docs.gitlab.com/ce/api/discussions.html#list-project-merge-request-discussion-items 
   /// </summary>
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

   /// <summary>
   /// Used to create new discussions
   /// https://docs.gitlab.com/ce/api/discussions.html#create-new-merge-request-thread
   /// </summary>
   public struct DiscussionParameters
   {
      public string Body;
      public Position? Position;

      public string ToQueryString()
      {
         return "?body=" + WebUtility.UrlEncode(Body) + Position?.ToQueryString() ?? "";
      }
   }
}
