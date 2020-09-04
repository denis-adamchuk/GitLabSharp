using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/discussions.html#get-single-merge-request-discussion-item
   /// </summary>
   public class Discussion
   {
      [JsonProperty]
      public string Id { get; protected set; }

      [JsonProperty]
      public IEnumerable<DiscussionNote> Notes { get; protected set; }

      [JsonProperty]
      public bool Individual_Note { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/discussions.html#list-project-merge-request-discussion-items
   /// </summary>
   public class Position
   {
      [JsonProperty]
      public string Old_Path { get; protected set; }

      [JsonProperty]
      public string New_Path { get; protected set; }

      [JsonProperty]
      public string Old_Line { get; protected set; }

      [JsonProperty]
      public string New_Line { get; protected set; }

      [JsonProperty]
      public string Base_SHA { get; protected set; }

      [JsonProperty]
      public string Head_SHA { get; protected set; }

      [JsonProperty]
      public string Start_SHA { get; protected set; }
   }

   /// <summary>
   /// Description of a note that belongs to a discussion
   /// https://docs.gitlab.com/ce/api/discussions.html#list-project-merge-request-discussion-items
   /// </summary>
   public class DiscussionNote
   {
      public DiscussionNote(int id, string body, DateTime created_At, DateTime updated_At, User author, string type,
         bool system, bool resolvable, bool resolved, Position position)
      {
         Id = id;
         Body = body;
         Created_At = created_At;
         Updated_At = updated_At;
         Author = author;
         Type = type;
         System = system;
         Resolvable = resolvable;
         Resolved = resolved;
         Position = position;
      }

      [JsonProperty]
      public int Id { get; protected set; }

      [JsonProperty]
      public string Body { get; protected set; }

      [JsonProperty]
      public DateTime Created_At { get; protected set; }

      [JsonProperty]
      public DateTime Updated_At { get; protected set; }

      [JsonProperty]
      public User Author { get; protected set; }

      [JsonProperty]
      public string Type { get; protected set; }

      [JsonProperty]
      public bool System { get; protected set; }

      [JsonProperty]
      public bool Resolvable { get; protected set; }

      [JsonProperty]
      public bool Resolved { get; protected set; }

      [JsonProperty]
      public Position Position { get; protected set; } // notes with type DiffNote must have it (others must not)
   }
}
