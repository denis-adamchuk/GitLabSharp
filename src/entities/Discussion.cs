using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/discussions.html#get-single-merge-request-discussion-item
   /// </summary>
   public struct Discussion
   {
      public string Id;
      public IEnumerable<DiscussionNote> Notes;
      public bool Individual_Note;
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/discussions.html#list-project-merge-request-discussion-items
   /// </summary>
   public struct Position
   {
      public string Old_Path;
      public string New_Path;
      public string Old_Line;
      public string New_Line;
      public string Base_SHA;
      public string Head_SHA;
      public string Start_SHA;
   }

   /// <summary>
   /// Description of a note that belongs to a discussion
   /// https://docs.gitlab.com/ce/api/discussions.html#list-project-merge-request-discussion-items 
   /// </summary>
   public struct DiscussionNote
   {
      public int Id;
      public string Body;
      public DateTime Created_At;
      public DateTime Updated_At;
      public User Author;
      public string Type;
      public bool System;
      public bool Resolvable;
      public bool Resolved;
      public Position Position; // notes with type DiffNote must have it (others must not)
   }
}
