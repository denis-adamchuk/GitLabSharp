using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Discussion
   {
      public Discussion(Root root, string projectId, int mergeRequestId, string discussionId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
         DiscussionId = discussionId;
      }

      public void Load()
      {
      }

      private Root Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
      private string DiscussionId { get; }
   }
}
