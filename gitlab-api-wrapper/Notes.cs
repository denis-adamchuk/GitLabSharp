using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Notes
   {
      public Notes(Root root, string projectId, int mergeRequestId, string discussionId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
         DiscussionId = discussionId;
      }

      public void Load()
      {
      }

      public Note Note(int noteId)
      {
         return new Note(Root, ProjectId, MergeRequestId, discussionId);
      }

      private Root Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
      private string DiscussionId { get; }
   }
}
