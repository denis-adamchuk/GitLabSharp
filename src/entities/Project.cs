using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/projects.html#get-single-project
   /// </summary>
   public class Project
   {
      public Project(string projectName)
      {
         Path_With_Namespace = projectName;
      }

      [JsonProperty]
      public string Path_With_Namespace { get; protected set; }

      public override bool Equals(object obj)
      {
         return obj is Project project &&
                Path_With_Namespace == project.Path_With_Namespace;
      }

      public override int GetHashCode()
      {
         return -1038938045 + EqualityComparer<string>.Default.GetHashCode(Path_With_Namespace);
      }
   }
}
