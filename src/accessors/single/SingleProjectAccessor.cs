using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single project
   /// </summary>
   public class SingleProjectAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/1
      /// </summary>
      internal SingleProjectAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this project instance from Server and de-serialize it
      /// </summary>
      public Task<Project> LoadTaskAsync()
      {
         return GetTaskAsync<Project>(BaseUrl);
      }

      /// <summary>
      /// Get access to list of users of this project
      /// </summary>
      public UserAccessor Users => new UserAccessor(Client, BaseUrl + "/users");

      /// <summary>
      /// Get access to a list of merge requests of this project
      /// </summary>
      public MergeRequestAccessor MergeRequests => new MergeRequestAccessor(Client, BaseUrl + "/merge_requests");

      /// <summary>
      /// Get access to git repository
      /// </summary>
      public SingleRepositoryAccessor Repository => new SingleRepositoryAccessor(Client, BaseUrl + "/repository");
   }
}

