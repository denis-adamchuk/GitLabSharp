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

      /// <summary>
      /// Execute Http GET request and return a value of X-Total response header
      /// </summary>
      internal int Count(string url)
      {
         Client.Get(url);

         if (!Client.ResponseHeaders.AllKeys.Contains("X-Total"))
         {
            throw new ApplicationException("Cannot calculate count");
         }

         int count = 0;
         if (!int.TryParse(Client.ResponseHeaders["X-Total"], out count))
         {
            throw new ApplicationException("Cannot calculate count");
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
   }
}
