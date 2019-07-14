using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class MergeRequest
   {
      public MergeRequest(Root root, string projectId, int mergeRequestId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
      }

      public void Load()
      {
      }

      public Versions Versions()
      {
         return new Versions(Root, ProjectId, MergeRequestId);
      }

      public Discussions Discussions()
      {
         return new Discussions(Root, ProjectId, MergeRequestId);
      }

      public 

      private Root Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
   }
}
