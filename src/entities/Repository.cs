using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/repositories.html#compare-branches-tags-or-commits
   /// </summary>
   public struct Comparison
   {
      public Commit Commit;
      public IEnumerable<Commit> Commits;
      public IEnumerable<DiffStruct> Diffs;
   }

   /// <summary>
   /// https://docs.gitlab.com/ee/api/repository_files.html#get-file-from-repository
   /// <summary>
   public struct File
   {
      public string File_Name;
      public string File_Path;
      public string Size;
      public string Encoding;
      public string Content;
      public string Ref;
   }
}

