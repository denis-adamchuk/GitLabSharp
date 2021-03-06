﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
      async internal Task<int> CountTaskAsync(string url)
      {
         await makeRequestAsync(url, "GET");
         Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
         return calculateCount(url);
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

      /// <summary>
      /// Execute Http GET request asynchronously, de-serialize a response into a new T object instance
      /// Additionally provides a total count of items from X-Total response header.
      /// </summary>
      async internal Task<Tuple<T, int>> GetAndCalculateCountTaskAsync<T>(string url)
      {
         T x = await makeRequestAndDeserializeResponseAsync<T>(url, "GET");
         return new Tuple<T, int>(x, calculateCount(url));
      }

      private int calculateCount(string url)
      {
         if (!Client.ResponseHeaders.AllKeys.Contains("X-Total"))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key is missing", null);
         }

         if (!int.TryParse(Client.ResponseHeaders["X-Total"], out int count))
         {
            throw new GitLabSharpException(url, "Cannot calculate count, X-Total key has invalid value", null);
         }

         return count;
      }
   }
}

