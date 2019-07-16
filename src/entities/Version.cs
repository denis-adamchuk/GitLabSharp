using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-a-single-mr-diff-version
   /// </summary>
   public class Version
   {
      public int Id;
      public DiffRefs Refs;
      public System.DateTime CreatedAt;
   }
}

