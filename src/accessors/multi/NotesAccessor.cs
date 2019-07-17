using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a list of notes
   /// </summary>
   public class NotesAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/notes
      /// </summary>
      internal NotesAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of notes from Server and de-serialize it
      /// </summary>
      public List<Note> Load()
      {
         return Get<List<Note>>(BaseUrl);
      }

      /// <summary>
      /// Get access to a single note by Id
      /// </summary>
      public SingleNoteAccessor Get(int noteId)
      {
         return new SingleNoteAccessor(Client, BaseUrl + "/" + noteId.ToString());
      }

      /// <summary>
      /// Create a new note with given body
      /// </summary>
      public Note CreateNew(CreateNewNoteParameters parameters)
      {
         return Post<Note>(BaseUrl + parameters.ToQueryString());
      }
   }
}
