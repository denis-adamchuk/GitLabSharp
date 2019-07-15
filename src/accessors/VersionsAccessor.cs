using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class VersionsAccessor
   {
      public VersionsAccessor(RootAccessor root, string projectId, int mergeRequestId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
      }

      public List<GitLabSharp.Version> All()
      {
         throw new NotImplementedException();
      }

      public GitLabSharp.Version Get(int versionId)
      {
         throw new NotImplementedException();
      }

      private RootAccessor Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
   }
}

