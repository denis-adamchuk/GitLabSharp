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
   /// Provides access to a single discussion. GitLab's discussion includes all its discussion notes.
   /// Note, this class does not provide access to individual notes within a discussion for their deletion or modification. 
   /// NotesAccessor can be easily used for this purpose.
   /// </summary>
   public class SingleDiscussionAccessor : BaseLoader<Discussion>
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/discussions/1
      /// </summary>
      internal SingleDiscussionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this discussion instance from Server and de-serialize it
      /// </summary>
      Discussion Details()
      {
         return DoLoad(BaseUrl);
      }

      /// <summary>
      /// Resolve a discussion thread
      /// </summary>
      /// <param name="resolve">true - resolve, false - unresolve</param>
      void Resolve(bool resolve)
      {
         HttpClient.Put(BaseUrl + "?resolved=" + resolve.ToString());
      }

      /// <summary>
      /// Create a new note within this discussion
      /// </summary>
      void CreateNewNote(string body)
      {
         HttpClient.Post(BaseUrl + "?body=" + WebUtility.UrlEncode(body));
      }
   }
}
