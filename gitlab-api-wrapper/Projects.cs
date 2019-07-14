using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Projects
   {
      public Projects(Root root)
      {
         Root = root;
      }

      public struct Filter
      {
         public bool Public;
      }

      public List<Project> Load(Filter filter)
      {
         throw new NotImplementedException();
      }

      public Project Project(string id)
      {
         return new Project(root, id);
      }

      private Root Root { get; }
   }
}
