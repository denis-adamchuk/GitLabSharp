﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Version = GitLabSharp.Entities.Version;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of versions
   /// </summary>
   public class VersionAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/versions
      /// </summary>
      internal VersionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of versions from Server and de-serialize it
      /// </summary>
      public Task<IEnumerable<Version>> LoadTaskAsync(PageFilter pageFilter)
      {
         return GetTaskAsync<IEnumerable<Version>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of versions from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Version>> LoadAllTaskAsync()
      {
         return GetAllTaskAsync<Version>(BaseUrl + "?");
      }

      /// <summary>
      /// Get access to a single version by Id
      /// </summary>
      public SingleVersionAccessor Get(int id)
      {
         if (id == 0)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by zero version Id", null);
         }
         return new SingleVersionAccessor(Client, BaseUrl + "/" + id.ToString());
      }
   }
}

