using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class RootAccessor
   {
      public RootAccessor(string host, string token)
      {
         Host = host;
         Token = token;
      }

      public User CurrentUser()
      {
         throw new NotImplementedException();
      }

      public ProjectsAccessor Projects()
      {
         return new ProjectsAccessor(this);
      }

      public string Host { get; }
      public string Token { get; }
   }
}
