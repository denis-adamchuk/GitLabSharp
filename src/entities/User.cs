using Newtonsoft.Json;
using System.Collections.Generic;

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

      public override bool Equals(object obj)
      {
         return obj is User user &&
                Id == user.Id &&
                Name == user.Name &&
                Username == user.Username &&
                EMail == user.EMail;
      }

      public override int GetHashCode()
      {
         int hashCode = -618108754;
         hashCode = hashCode * -1521134295 + Id.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EMail);
         return hashCode;
      }
   }
}
