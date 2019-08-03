using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a single merge request instance
   /// </summary>
   public class SingleMergeRequestAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/4/merge_requests/1
      /// </summary>
      internal SingleMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this merge request from Server and de-serialize it
      /// </summary>
      public MergeRequest Load()
      {
         return Get<MergeRequest>(BaseUrl);
      }

      /// <summary>
      /// Load information about this merge request from Server and de-serialize it
      /// </summary>
      public Task<MergeRequest> LoadTaskAsync()
      {
         return GetTaskAsync<MergeRequest>(BaseUrl);
      }

      /// <summary>
      /// Get access to a list of versions of this merge request
      /// </summary>
      public VersionsAccessor Versions => new VersionsAccessor(Client, BaseUrl + "/versions");

      /// <summary>
      /// Get access to a list of discussions of this merge request
      /// </summary>
      public DiscussionsAccessor Discussions => new DiscussionsAccessor(Client, BaseUrl + "/discussions");

      /// <summary>
      /// Get access to a list of notes of this merge request
      /// </summary>
      public NotesAccessor Notes => new NotesAccessor(Client, BaseUrl + "/notes");

      /// <summary>
      /// Add spent time to the merge request of this merge request
      /// </summary>
      public SpentTime AddSpentTime(AddSpentTimeParameters parameters)
      {
         return Post<SpentTime>(BaseUrl + "/add_spent_time?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Add spent time to the merge request of this merge request
      /// </summary>
      public Task<SpentTime> AddSpentTimeAsync(AddSpentTimeParameters parameters)
      {
         return PostTaskAsync<SpentTime>(BaseUrl + "/add_spent_time?" + parameters.ToQueryString());
      }
   }
}
