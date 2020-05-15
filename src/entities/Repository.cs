using Newtonsoft.Json;
using System.Collections.Generic;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/repositories.html#compare-branches-tags-or-commits
   /// </summary>
   public class Comparison
   {
      [JsonProperty]
      public Commit Commit { get; protected set; }

      [JsonProperty]
      public IEnumerable<Commit> Commits { get; protected set; }

      [JsonProperty]
      public IEnumerable<DiffStruct> Diffs { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ee/api/repository_files.html#get-file-from-repository
   /// <summary>
   public class File
   {
      [JsonProperty]
      public string File_Name { get; protected set; }

      [JsonProperty]
      public string File_Path { get; protected set; }

      [JsonProperty]
      public string Size { get; protected set; }

      [JsonProperty]
      public string Encoding { get; protected set; }

      [JsonProperty]
      public string Content { get; protected set; }

      [JsonProperty]
      public string Ref { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ee/api/branches.html#get-single-repository-branch
   /// </summary>
   public class Branch
   {
      [JsonProperty]
      public string Name { get; protected set; }

      [JsonProperty]
      public Commit Commit { get; protected set; }
   }
}
