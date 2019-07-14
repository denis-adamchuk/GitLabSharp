using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class User
   {
      public User(Root root)
      {
         Root = root;
      }

      private Root Root { get; }
   }
}
