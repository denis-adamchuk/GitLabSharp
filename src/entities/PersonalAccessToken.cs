using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/personal_access_tokens.html
   /// </summary>
   public class PersonalAccessToken
   {
      [JsonProperty]
      public int Id { get; protected set; }

      [JsonProperty]
      public string Name { get; protected set; }

      [JsonProperty]
      public bool Revoked { get; protected set; }

      [JsonProperty]
      public DateTime? Created_At { get; protected set; }

      [JsonProperty]
      public IEnumerable<string> Scopes { get; protected set; }

      [JsonProperty]
      public int UserId { get; protected set; }

      [JsonProperty]
      public DateTime? Last_Used_At { get; protected set; }

      [JsonProperty]
      public bool Active { get; protected set; }

      [JsonProperty]
      public DateTime? Expires_At { get; protected set; }

      [JsonProperty]
      public string Token { get; protected set; }
   }
}

