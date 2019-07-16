using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class CurrentUserAccessor : BaseLoader<User>
   {
      internal CurrentUserAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }
   }
}
