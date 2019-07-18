using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a list of versions
   /// </summary>
   public class VersionsAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/versions
      /// </summary>
      internal VersionsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of versions from Server and de-serialize it
      /// </summary>
      public List<Version> Load(PageFilter pageFilter)
      {
         return Get<List<Version>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it
      /// </summary>
      public List<Version> LoadAll()
      {
         return GetAll<List<Version>, Version>(BaseUrl + "?");
      }

      /// <summary>
      /// Get number of versions
      /// </summary>
      public int Count()
      {
         return Count(BaseUrl);
      }
   }
}

