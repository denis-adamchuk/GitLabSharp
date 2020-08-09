using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr-commits
   /// </summary>
   public class Commit
   {
      [JsonProperty]
      public string Id { get; protected set; }

      [JsonProperty]
      public DateTime Created_At { get; protected set; }

      [JsonProperty]
      public string Title { get; protected set; }

      [JsonProperty]
      public string Message { get; protected set; }

      [JsonProperty]
      public IEnumerable<string> Parent_Ids { get; protected set; }

      public override bool Equals(object obj)
      {
         return obj is Commit commit &&
                Id == commit.Id &&
                Created_At == commit.Created_At &&
                Title == commit.Title &&
                Message == commit.Message &&
                ((Parent_Ids == null && commit.Parent_Ids == null) ||
                   Enumerable.SequenceEqual(Parent_Ids, commit.Parent_Ids));
      }

      public override int GetHashCode()
      {
         throw new NotImplementedException();
      }
   }
}

