using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/projects.html#get-single-project
   /// </summary>
   public class Project
   {
      public int Id;
      public string Path_With_Namespace;
   }
}
