using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single repository file
   /// </summary>
   public class SingleRepositoryFileAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/repository/files/filename
      /// </summary>
      internal SingleRepositoryFileAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about file from Server and de-serializes it
      /// </summary>
      public Task<File> LoadTaskAsync(string sha)
      {
         return GetTaskAsync<File>(BaseUrl + "?ref=" + sha);
      }
   }
}

