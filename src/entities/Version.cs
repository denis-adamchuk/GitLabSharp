using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class Version
   {
      public Version(Dictionary<string, object> json)
      {
         throw new NotImplementedException();
      }

      public int Id;
      public DiffRefs Refs;
      public System.DateTime CreatedAt;
   }
}

