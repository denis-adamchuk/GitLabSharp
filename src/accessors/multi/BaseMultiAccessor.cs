using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Base class for all Accessors that provide access to sets of things
   /// </summary>
   public class BaseMultiAccessor : BaseAccessor
   {
      internal BaseMultiAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }
      
      // TODO Get rid of copy/paste below

      /// <summary>
      /// Execute Http GET request and return a value of X-Total response header
      /// </summary>
      internal int Count(string url)
      {
         safeRequest(url, "GET");

         if (!Client.ResponseHeaders.AllKeys.Contains("X-Total"))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key is missing");
         }

         int count = 0;
         if (!int.TryParse(Client.ResponseHeaders["X-Total"], out count))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key has invalid value");
         }

         return count;
      }

      /// <summary>
      /// Execute Http GET request and return a value of X-Total response header
      /// </summary>
      async internal Task<int> CountTaskAsync(string url)
      {
         await requestTaskAsync(url, "GET");

         if (!Client.ResponseHeaders.AllKeys.Contains("X-Total"))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key is missing");
         }

         int count = 0;
         if (!int.TryParse(Client.ResponseHeaders["X-Total"], out count))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key has invalid value");
         }

         return count;
      }

      /// <summary>
      /// Execute multiple Http GET requests and merge results in a single list
      /// </summary>
      internal TList GetAll<TList, TItem>(string url) where TList : List<TItem>, new()
      {
         TList result = new TList();

         int total = Count(url);
         int perPage = 100;
         int pages = total / perPage + (total % perPage > 0 ? 1 : 0);
         for (int iPage = 0; iPage < pages; ++iPage)
         {
            PageFilter pageFilter = new PageFilter { PageNumber = iPage + 1, PerPage = perPage };
            TList chunk = Get<TList>(url + pageFilter.ToQueryString());
            result.AddRange(chunk);
         }

         return result;
      }

      /// <summary>
      /// Execute multiple Http GET requests and merge results in a single list
      /// </summary>
      async internal Task<TList> GetAllTaskAsync<TList, TItem>(string url) where TList : List<TItem>, new()
      {
         TList result = new TList();

         Task<int> countTask = CountTaskAsync(url);
         int total = await countTask;

         int perPage = 100;
         int pages = total / perPage + (total % perPage > 0 ? 1 : 0);
         for (int iPage = 0; iPage < pages; ++iPage)
         {
            PageFilter pageFilter = new PageFilter { PageNumber = iPage + 1, PerPage = perPage };
            TList chunk = await GetTaskAsync<TList>(url + pageFilter.ToQueryString());
            System.Diagnostics.Debug.WriteLine("received response for request");
            result.AddRange(chunk);
         }

         return result;
      }
   }
}

