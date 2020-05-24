using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/notes.html#get-single-merge-request-note
   /// </summary>
   public class Note
   {
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
      public bool System { get; protected set; }

      [JsonProperty]
      public string Type { get; protected set; }

      [JsonProperty]
      public Position Position { get; protected set; } // notes with type DiffNote must have it (others must not)

      public override bool Equals(object obj)
      {
         return obj is Note note &&
                Id == note.Id &&
                Body == note.Body &&
                Created_At == note.Created_At &&
                Updated_At == note.Updated_At &&
                EqualityComparer<User>.Default.Equals(Author, note.Author) &&
                System == note.System &&
                Type == note.Type &&
                EqualityComparer<Position>.Default.Equals(Position, note.Position);
      }

      public override int GetHashCode()
      {
         int hashCode = -310762489;
         hashCode = hashCode * -1521134295 + Id.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Body);
         hashCode = hashCode * -1521134295 + Created_At.GetHashCode();
         hashCode = hashCode * -1521134295 + Updated_At.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(Author);
         hashCode = hashCode * -1521134295 + System.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
         hashCode = hashCode * -1521134295 + EqualityComparer<Position>.Default.GetHashCode(Position);
         return hashCode;
      }
   }
}
