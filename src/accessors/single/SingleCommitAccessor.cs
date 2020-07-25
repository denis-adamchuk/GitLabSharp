using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single version
   /// </summary>
   public class SingleCommitAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/1/merge_requests/1/commits/1
      /// or https://gitlab.example.com/api/v4/projects/1/repository/commits/1
      /// </summary>
      internal SingleCommitAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this Commit instance from Server and de-serialize it
      /// </summary>
      public Task<Commit> LoadTaskAsync()
      {
         return GetTaskAsync<Commit>(BaseUrl);
      }

      /// <summary>
      /// Load information about references of this Commit from Server and de-serialize it
      /// </summary>
      public Task<IEnumerable<CommitRef>> LoadRefsTaskAsync()
      {
         return GetTaskAsync<IEnumerable<CommitRef>>(BaseUrl + "/refs");
      }
   }
}

