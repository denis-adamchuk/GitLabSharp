using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class DiscussionsAccessor
   {
      public DiscussionsAccessor(RootAccessor root, string projectId, int mergeRequestId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
      }

      public List<Discussion> All()
      {
         throw new NotImplementedException();
      }

      public Discussion Get(string discussionId)
      {
         throw new NotImplementedException();
      }

      public void New(DiscussionParameters parameters)
      {
         throw new NotImplementedException();
      }

      private RootAccessor Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
   }
}
