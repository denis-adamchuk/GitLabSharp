using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of commits
   /// </summary>
   public class CommitAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/commits
      /// </summary>
      internal CommitAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of commits from Server and de-serialize it
      /// </summary>
      public List<Commit> Load(PageFilter pageFilter)
      {
         return Get<List<Commit>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load a single page from a full list of commits from Server and de-serialize it
      /// </summary>
      public Task<List<Commit>> LoadTaskAsync(PageFilter pageFilter)
      {
         return GetTaskAsync<List<Commit>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of commits from Server and de-serialize it
      /// </summary>
      public List<Commit> LoadAll()
      {
         return GetAll<List<Commit>, Commit>(BaseUrl + "?");
      }

      /// <summary>
      /// Load full list of commits from Server and de-serialize it (async)
      /// </summary>
      public Task<List<Commit>> LoadAllTaskAsync()
      {
         return GetAllTaskAsync<List<Commit>, Commit>(BaseUrl + "?");
      }

      /// <summary>
      /// Get number of commits
      /// </summary>
      public int Count()
      {
         return Count(BaseUrl);
      }

      /// <summary>
      /// Get number of commits asynchronously
      /// </summary>
      async public Task<int> CountTaskAsync()
      {
         return await CountTaskAsync(BaseUrl);
      }
   }
}

