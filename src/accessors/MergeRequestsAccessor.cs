using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class MergeRequestsAccessor
   {
      public MergeRequestsAccessor(RootAccessor root, string projectId)
      {
         Root = root;
         ProjectId = projectId;
      }

      public struct Filter
      {
         public enum StateFilter
         {
            Open,
            Closed,
            Merged,
            All
         }

         public enum WorkInProgressFilter
         {
            Yes,
            No,
            All
         }

         string Labels;
         StateFilter State;
         WorkInProgressFilter WIP;
      }

      public List<MergeRequest> All(Filter filter)
      {
         throw new NotImplementedException();
      }

      public MergeRequest Get(int mergeRequestId)
      {
         throw new NotImplementedException();
      }

      public VersionsAccessor Versions(int mergeRequestId)
      {
         return new VersionsAccessor(Root, ProjectId, mergeRequestId);
      }

      public DiscussionsAccessor Discussions(int mergeRequestId)
      {
         return new DiscussionsAccessor(Root, ProjectId, mergeRequestId);
      }

      public NotesAccessor Notes(int mergeRequestId)
      {
         return new NotesAccessor(Root, ProjectId, mergeRequestId);
      }

      public void AddSpentTime(int mergeRequestId, TimeSpan timeSpan)
      {
         throw new NotImplementedException();
      }

      private RootAccessor Root { get; }
      private string ProjectId { get; }
   }
}
