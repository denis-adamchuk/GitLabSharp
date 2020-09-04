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
   }
}

