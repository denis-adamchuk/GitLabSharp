using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a list of discussions
   /// </summary>
   public class DiscussionsAccessor : BaseLoader<List<Discussion>>
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/discussions
      /// </summary>
      internal DiscussionsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it
      /// </summary>
      public List<Discussion> Details()
      {
         return DoLoad(BaseUrl);
      }

      /// <summary>
      /// Get access to a single discussion by Id
      /// </summary>
      public SingleDiscussionAccessor Get(string discussionId)
      {
         return new SingleDiscussionAccessor(HttpClient, BaseUrl + "/" + discussionId);
      }
      
      /// <summary>
      /// Create a new discussion with given parameters
      /// </summary>
      public void CreateNew(DiscussionParameters parameters)
      {
         HttpClient.Post(BaseUrl + parameters.ToQueryString());
      }
   }
}
