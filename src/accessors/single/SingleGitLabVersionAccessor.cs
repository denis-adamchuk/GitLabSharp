using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to information about gitlab version
   /// </summary>
   public class SingleGitLabVersionAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/version
      /// </summary>
      internal SingleGitLabVersionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about gitlab version from Server and de-serializes it
      /// </summary>
      public Task<GitLabVersion> LoadTaskAsync()
      {
         return GetTaskAsync<GitLabVersion>(BaseUrl);
      }
   }
}
