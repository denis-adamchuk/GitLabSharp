using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class RootAccessor : BaseAccessor
   {
      internal RootAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public CurrentUserAccessor CurrentUser()
      {
         return new CurrentUserAccessor(_httpClient, _baseUrl + "/user");
      }

      public ProjectsAccessor Projects()
      {
         return new ProjectsAccessor(_httpClient, _baseUrl + "/projects");
      }
   }
}
