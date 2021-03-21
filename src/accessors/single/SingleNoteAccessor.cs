using System.Threading.Tasks;

namespace GitLabSharp.Accessors
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
      /// Delete note
      /// </summary>
      async public Task<bool> DeleteTaskAsync()
      {
         await base.DeleteTaskAsync(BaseUrl);
         return true;
      }
   }
}
