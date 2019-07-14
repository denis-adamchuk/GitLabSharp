using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class MergeRequests
   {
      public MergeRequests(Root root, string projectId)
      {
         Root = root;
         ProjectId = projectId;
      }

      public struct Filter
      {
      }

      public List<MergeRequest> Load(Filter filter)
      {
         throw new NotImplementedException();
      }

      public MergeRequest MergeRequest(int mergeRequestId)
      {
         return new MergeRequest(root, ProjectId, mergeRequestId);
      }

      private Root Root { get; }
      private string ProjectId { get; }
   }
}
