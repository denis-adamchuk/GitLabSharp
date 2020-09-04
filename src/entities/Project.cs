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
      [JsonProperty]
      public string Path_With_Namespace { get; protected set; }

      [JsonProperty]
      public string Merge_Method { get; protected set; }
   }
}

