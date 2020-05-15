using Newtonsoft.Json;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/users.html#single-user
   /// </summary>
   public class User
   {
      [JsonProperty]
      public int Id { get; protected set; }

      [JsonProperty]
      public string Name { get; protected set; }

      [JsonProperty]
      public string Username { get; protected set; }

      [JsonProperty]
      public string EMail { get; protected set; }
   }
}
