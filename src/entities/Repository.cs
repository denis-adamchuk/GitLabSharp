using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

      [JsonProperty]
      public bool Compare_Timeout { get; protected set; }
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

      public override bool Equals(object obj)
      {
         return obj is File file &&
                File_Name == file.File_Name &&
                File_Path == file.File_Path &&
                Size == file.Size &&
                Encoding == file.Encoding &&
                Content == file.Content &&
                Ref == file.Ref;
      }

      public override int GetHashCode()
      {
         int hashCode = 229926954;
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(File_Name);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(File_Path);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Size);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Encoding);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ref);
         return hashCode;
      }
   }

   /// <summary>
   /// https://docs.gitlab.com/ee/api/branches.html#get-single-repository-branch
   /// </summary>
   public class Branch
   {
      public Branch(string name, Commit commit)
      {
         Name = name;
         Commit = commit;
      }

      [JsonProperty]
      public string Name { get; protected set; }

      [JsonProperty]
      public Commit Commit { get; protected set; }
   }
}
