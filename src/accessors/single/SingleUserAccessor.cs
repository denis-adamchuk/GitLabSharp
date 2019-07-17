using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to information about user
   /// </summary>
   public class SingleUserAccessor : BaseAccessor<User>
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/users/1
      /// </summary>
      internal SingleUserAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about user from Server and de-serializes it
      /// </summary>
      User Details()
      {
         return DoLoad(BaseUrl);
      }
   }
}
