using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of Branches
   /// </summary>
   public class BranchAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/branches
      /// </summary>
      internal BranchAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load list of Branches from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Branch>> LoadTaskAsync(PageFilter pageFilter)
      {
         return GetTaskAsync<IEnumerable<Branch>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of Branches from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Branch>> LoadAllTaskAsync(string search)
      {
         return GetAllTaskAsync<Branch>(BaseUrl + "?search=" + Uri.EscapeDataString(search) + "&");
      }

      /// <summary>
      /// Get access to a single Branch by Id
      /// </summary>
      public SingleBranchAccessor Get(string name)
      {
         if (String.IsNullOrWhiteSpace(name))
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by empty name", null);
         }
         return new SingleBranchAccessor(Client, BaseUrl + "/" + name.ToString());
      }

      /// <summary>
      /// Create a new Branch with given body (async)
      /// </summary>
      public Task<Branch> CreateNewTaskAsync(CreateNewBranchParameters parameters)
      {
         return PostTaskAsync<Branch>(BaseUrl + "?" + parameters.ToQueryString());
      }
   }
}

