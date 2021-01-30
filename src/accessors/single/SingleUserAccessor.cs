using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to information about user
   /// </summary>
   public class SingleUserAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/users/1 or https://gitlab.example.com/api/v4/user
      /// </summary>
      internal SingleUserAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about user from Server and de-serializes it
      /// </summary>
      public User Load()
      {
         return Get<User>(BaseUrl);
      }

      /// <summary>
      /// Loads information about user from Server and de-serializes it
      /// </summary>
      public Task<User> LoadTaskAsync()
      {
         return GetTaskAsync<User>(BaseUrl);
      }
   }
}
