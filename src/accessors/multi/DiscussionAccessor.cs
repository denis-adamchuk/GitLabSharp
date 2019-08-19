using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
      /// Load a single page from a full list of discussions from Server and de-serialize it
      /// </summary>
      public List<Discussion> Load(PageFilter pageFilter)
      {
         return Get<List<Discussion>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it
      /// </summary>
      public List<Discussion> LoadAll()
      {
         return GetAll<List<Discussion>, Discussion>(BaseUrl + "?");
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it
      /// </summary>
      public Task<List<Discussion>> LoadAllTaskAsync()
      {
         return GetAllTaskAsync<List<Discussion>, Discussion>(BaseUrl + "?");
      }

      /// <summary>
      /// Get number of discussions
      /// Note: PageFilter is ignored
      /// </summary>
      public int Count()
      {
         return Count(BaseUrl);
      }

      /// <summary>
      /// Get access to a single discussion by Id
      /// </summary>
      public SingleDiscussionAccessor Get(string discussionId)
      {
         return new SingleDiscussionAccessor(Client, BaseUrl + "/" + discussionId);
      }

      /// <summary>
      /// Create a new discussion with given parameters
      /// </summary>
      public Discussion CreateNew(NewDiscussionParameters parameters)
      {
         return Post<Discussion>(BaseUrl + "?" + parameters.ToQueryString());
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
