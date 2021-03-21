using System;
using System.Collections.Generic;
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
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/5/commits
      /// or https://gitlab.example.com/api/v4/projects/5/repository/commits
      /// </summary>
      internal CommitAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of commits from Server and de-serialize it
      /// </summary>
      public Task<IEnumerable<Commit>> LoadTaskAsync(PageFilter pageFilter)
      {
         return GetTaskAsync<IEnumerable<Commit>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of commits from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Commit>> LoadAllTaskAsync()
      {
         return GetAllTaskAsync<Commit>(BaseUrl + "?");
      }

      /// <summary>
      /// Get number of commits asynchronously
      /// </summary>
      async public Task<int> CountTaskAsync()
      {
         return await CountTaskAsync(BaseUrl);
      }

      /// <summary>
      /// Get access to a single commit by SHA
      /// </summary>
      public SingleCommitAccessor Get(string sha)
      {
         if (String.IsNullOrWhiteSpace(sha))
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by empty sha", null);
         }
         return new SingleCommitAccessor(Client, BaseUrl + "/" + Uri.EscapeDataString(sha));
      }
   }
}

