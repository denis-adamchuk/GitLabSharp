using GitLabSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of users
   /// </summary>
   public class UserAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/users
      /// </summary>
      internal UserAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Get access to a single user by id
      /// </summary>
      public SingleUserAccessor Get(int id)
      {
         if (id == 0)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by zero user id", null);
         }
         return new SingleUserAccessor(Client, BaseUrl + "/" + id.ToString());
      }

      /// <summary>
      /// Search users by name (async)
      /// </summary>
      public Task<IEnumerable<User>> SearchTaskAsync(string name)
      {
         return GetAllTaskAsync<User>(BaseUrl + "?search=" + WebUtility.UrlEncode(name) + "&");
      }

      /// <summary>
      /// Search users by name (async)
      /// </summary>
      public Task<IEnumerable<User>> SearchByUsernameTaskAsync(string username)
      {
         return GetAllTaskAsync<User>(BaseUrl + "?username=" + WebUtility.UrlEncode(username) + "&");
      }
   }
}

