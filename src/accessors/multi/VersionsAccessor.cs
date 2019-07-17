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
   public class VersionsAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/versions
      /// </summary>
      internal VersionsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of versions from Server and de-serialize it
      /// </summary>
      public List<Version> Load()
      {
         return Get<List<Version>>(BaseUrl);
      }
   }
}

