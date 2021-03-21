using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of discussions
   /// </summary>
   public class DiscussionAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/discussions
      /// </summary>
      internal DiscussionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it
      /// </summary>
      public Task<IEnumerable<Discussion>> LoadAllTaskAsync()
      {
         return GetAllTaskAsync<Discussion>(BaseUrl + "?");
      }

      /// <summary>
      /// Get access to a single discussion by Id
      /// </summary>
      public SingleDiscussionAccessor Get(string discussionId)
      {
         if (discussionId == null)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by null discussion id", null);
         }
         return new SingleDiscussionAccessor(Client, BaseUrl + "/" + discussionId);
      }

      /// <summary>
      /// Create a new discussion with given parameters
      /// </summary>
      public Task<Discussion> CreateNewTaskAsync(NewDiscussionParameters parameters)
      {
         return PostTaskAsync<Discussion>(BaseUrl + "?" + parameters.ToQueryString());
      }
   }
}
