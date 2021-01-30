using Newtonsoft.Json;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/version.html
   /// </summary>
   public class GitLabVersion
   {
      [JsonProperty]
      public string Version { get; protected set; }

      [JsonProperty]
      public string Revision { get; protected set; }
   }
}

