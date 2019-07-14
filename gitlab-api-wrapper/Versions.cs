using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Versions
   {
      public Versions(Root root, string projectId, int mergeRequestId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
      }

      private Root Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
   }
}
