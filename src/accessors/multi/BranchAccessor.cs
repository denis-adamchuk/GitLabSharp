using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
      /// Load a single page from a full list of Branches from Server and de-serialize it
      /// </summary>
      public IEnumerable<Branch> Load(PageFilter pageFilter)
      {
         return Get<IEnumerable<Branch>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of Branches from Server and de-serialize it
      /// </summary>
      public IEnumerable<Branch> LoadAll()
      {
         return GetAll<Branch>(BaseUrl + "?");
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
      /// Get number of Branches
      /// Branch: PageFilter is ignored
      /// </summary>
      public int Count()
      {
         return Count(BaseUrl);
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
      /// Create a new Branch with given body
      /// </summary>
      public Branch CreateNew(CreateNewBranchParameters parameters)
      {
         return Post<Branch>(BaseUrl + "?" + parameters.ToQueryString());
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

