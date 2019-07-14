using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Discussions
   {
      public Discussions(Root root, string projectId, int mergeRequestId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
      }

      public void Load()
      {
      }

      public Discussion Discussion(string discussionId)
      {
         return new Discussion(Root, ProjectId, MergeRequestId, discussionId);
      }

      private Root Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
   }
}
