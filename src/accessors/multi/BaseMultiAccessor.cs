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
   /// Base class for all Accessors that provide access to sets of things
   /// </summary>
   public class BaseMultiAccessor : BaseAccessor
   {
      internal BaseMultiAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Execute Http GET request and return a value of X-Total response header
      /// </summary>
      internal int Count(string url)
      {
         makeRequest(url, "GET");
         return calculateCount(url);
      }

      /// <summary>
      /// Execute Http GET request and return a value of X-Total response header
      /// </summary>
      async internal Task<int> CountTaskAsync(string url)
      {
         await makeRequestAsync(url, "GET");
         Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
         return calculateCount(url);
      }

      /// <summary>
      /// Execute multiple Http GET requests and merge results in a single list
      /// </summary>
      internal IEnumerable<TItem> GetAll<TItem>(string url)
      {
         List<TItem> result = new List<TItem>();

         int total = Count(url);
         int perPage = 100;
         int pages = total / perPage + (total % perPage > 0 ? 1 : 0);
         for (int iPage = 0; iPage < pages; ++iPage)
         {
            PageFilter pageFilter = new PageFilter(perPage, iPage + 1);
            IEnumerable<TItem> chunk = Get<List<TItem>>(url + pageFilter.ToQueryString());
            result.AddRange(chunk);
         }

         return result;
      }

      /// <summary>
      /// Execute multiple Http GET requests and merge results in a single list
      /// </summary>
      async internal Task<IEnumerable<TItem>> GetAllTaskAsync<TItem>(string url)
      {
         const int perPage = 100;
         List<TItem> result = new List<TItem>();

         PageFilter firstChunkFilter = new PageFilter(perPage, 1);
         IEnumerable<TItem> chunk = await GetTaskAsync<List<TItem>>(url + firstChunkFilter.ToQueryString());
         Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
         result.AddRange(chunk);

         int total = calculateCount(url);
         int pages = total / perPage + (total % perPage > 0 ? 1 : 0);
         for (int iPage = 1; iPage < pages; ++iPage)
         {
            PageFilter pageFilter = new PageFilter(perPage, iPage + 1);
            chunk = await GetTaskAsync<List<TItem>>(url + pageFilter.ToQueryString());
            Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
            result.AddRange(chunk);
         }

         return result;
      }

      private int calculateCount(string url)
      {
         if (!Client.ResponseHeaders.AllKeys.Contains("X-Total"))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key is missing", null);
         }

         int count = 0;
         if (!int.TryParse(Client.ResponseHeaders["X-Total"], out count))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key has invalid value", null);
         }

         return count;
      }
   }
}

