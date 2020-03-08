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
}

