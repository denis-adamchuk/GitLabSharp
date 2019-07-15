using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class ProjectsAccessor
   {
      public ProjectsAccessor(RootAccessor root)
      {
         Root = root;
      }

      public List<Project> All()
      {
         throw new NotImplementedException();
      }

      public Project Get(string id)
      {
         throw new NotImplementedException();
      }

      private RootAccessor Root { get; }
   }
}
