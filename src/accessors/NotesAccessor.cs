using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class NotesAccessor
   {
      public NotesAccessor(RootAccessor root, string projectId, int mergeRequestId)
      {
         Root = root;
         ProjectId = projectId;
         MergeRequestId = mergeRequestId;
      }

      public List<Note> All()
      {
         throw new NotImplementedException();
      }

      public Note Get(int noteId)
      {
         throw new NotImplementedException();
      }

      public void New(string body)
      {
         throw new NotImplementedException();
      }

      public void Delete(int noteId)
      {
         throw new NotImplementedException();
      }

      public void Modify(int noteId, string body, bool resolved)
      {
         throw new NotImplementedException();
      }

      private RootAccessor Root { get; }
      private string ProjectId { get; }
      private int MergeRequestId { get; }
   }
}
