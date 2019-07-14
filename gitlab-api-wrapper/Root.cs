using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Root
   {
      public Root(string host, string token)
      {
         Host = host;
         Token = token;
      }

      public User CurrentUser()
      {
         return new User(this);
      }

      public Projects Projects()
      {
         return new Projects(this);
      }

      public string Host { get; }
      public string Token { get; }
   }
}
