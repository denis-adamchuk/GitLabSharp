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
   }
}
