using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/users.html#single-user
   /// </summary>
   public class User
   {
      public int Id;
      public string Name;
      public string Username;
   }
}
