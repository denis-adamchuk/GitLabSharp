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
      public Project(int id, string path_With_Namespace, string merge_Method)
      {
         Id = id;
         Path_With_Namespace = path_With_Namespace;
         Merge_Method = merge_Method;
      }

      [JsonProperty]
      public int Id { get; protected set; }

      [JsonProperty]
      public string Path_With_Namespace { get; protected set; }

      [JsonProperty]
      public string Merge_Method { get; protected set; }
   }
}

