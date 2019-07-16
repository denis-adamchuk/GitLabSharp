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
   public class SingleNoteAccessor : BaseLoader<Note>
   {
      internal SingleNoteAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about note from Server and de-serializes it
      /// </summary>
      Note Details()
      {
         return DoLoad(BaseUrl);
      }

      /// <summary>
      /// Delete note
      /// </summary>
      public void Delete()
      {
         HttpClient.Delete(BaseUrl);
      }

      /// <summary>
      /// Modify note
      /// </summary>
      public void Modify(NoteModificationParameters parameters)
      {
         HttpClient.Put(BaseUrl + parameters.ToQueryString());
      }
   }
}
