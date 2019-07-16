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
   public class VersionsAccessor : BaseLoader<List<Version>>
   {
      internal VersionsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load full list of versions from Server and de-serialize it
      /// </summary>
      public List<Version> Details()
      {
         return DoLoad(BaseUrl);
      }
   }
}

