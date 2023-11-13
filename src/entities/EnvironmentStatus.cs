using Newtonsoft.Json;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// Undocumented object.
   /// </summary>
   public class EnvironmentStatus
   {
      [JsonProperty]
      public string Id { get; protected set; }

      [JsonProperty]
      public string Name { get; protected set; }

      [JsonProperty]
      public string Status { get; protected set; }

      [JsonProperty]
      public string External_Url { get; protected set; }

      [JsonProperty]
      public string External_Url_Formatted { get; protected set; }

      [JsonProperty]
      public bool Environment_Available { get; protected set; }
   }
}

