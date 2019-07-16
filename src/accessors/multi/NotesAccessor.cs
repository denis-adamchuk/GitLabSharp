using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class NotesAccessor : BaseLoader<List<Note>>
   {
      internal NotesAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public SingleNoteAccessor Single(int noteId)
      {
         return new SingleNoteAccessor(_httpClient, _baseUrl + "/" + noteId.ToString());
      }

      public void New(string body)
      {
         throw new NotImplementedException();
      }
   }
}
