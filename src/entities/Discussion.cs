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

      public override bool Equals(object obj)
      {
         return obj is Discussion discussion &&
                Id == discussion.Id &&
                ((Notes == null && discussion.Notes == null) || Enumerable.SequenceEqual(Notes, discussion.Notes)) &&
                Individual_Note == discussion.Individual_Note;
      }

      public override int GetHashCode()
      {
         throw new NotImplementedException();
      }
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

      public override bool Equals(object obj)
      {
         return obj is Position position &&
                Old_Path == position.Old_Path &&
                New_Path == position.New_Path &&
                Old_Line == position.Old_Line &&
                New_Line == position.New_Line &&
                Base_SHA == position.Base_SHA &&
                Head_SHA == position.Head_SHA &&
                Start_SHA == position.Start_SHA;
      }

      public override int GetHashCode()
      {
         int hashCode = -606002133;
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Old_Path);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(New_Path);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Old_Line);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(New_Line);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Base_SHA);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Head_SHA);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Start_SHA);
         return hashCode;
      }
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

      public override bool Equals(object obj)
      {
         return obj is DiscussionNote note &&
                Id == note.Id &&
                Body == note.Body &&
                Created_At == note.Created_At &&
                Updated_At == note.Updated_At &&
                EqualityComparer<User>.Default.Equals(Author, note.Author) &&
                Type == note.Type &&
                System == note.System &&
                Resolvable == note.Resolvable &&
                Resolved == note.Resolved &&
                EqualityComparer<Position>.Default.Equals(Position, note.Position);
      }

      public override int GetHashCode()
      {
         int hashCode = -2032422984;
         hashCode = hashCode * -1521134295 + Id.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Body);
         hashCode = hashCode * -1521134295 + Created_At.GetHashCode();
         hashCode = hashCode * -1521134295 + Updated_At.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(Author);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
         hashCode = hashCode * -1521134295 + System.GetHashCode();
         hashCode = hashCode * -1521134295 + Resolvable.GetHashCode();
         hashCode = hashCode * -1521134295 + Resolved.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<Position>.Default.GetHashCode(Position);
         return hashCode;
      }
   }
}
