using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a single note instance
   /// </summary>
   public class SingleNoteAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/notes/1
      /// </summary>
      internal SingleNoteAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about note from Server and de-serializes it
      /// </summary>
      public Note Load()
      {
         return Get<Note>(BaseUrl);
      }

      /// <summary>
      /// Delete note
      /// </summary>
      public void Delete()
      {
         Delete(BaseUrl);
      }

      /// <summary>
      /// Modify note
      /// </summary>
      public Note Modify(ModifyNoteParameters parameters)
      {
         return Put<Note>(BaseUrl + parameters.ToQueryString());
      }
   }
}
