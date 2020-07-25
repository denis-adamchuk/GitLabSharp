using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ee/api/commits.html#get-references-a-commit-is-pushed-to
   /// </summary>
   public class CommitRef
   {
      [JsonProperty]
      public string Type { get; protected set; }

      [JsonProperty]
      public string Name { get; protected set; }

      public override bool Equals(object obj)
      {
         return obj is CommitRef @ref &&
                Type == @ref.Type &&
                Name == @ref.Name;
      }

      public override int GetHashCode()
      {
         int hashCode = -1979447941;
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
         return hashCode;
      }
   }
}

