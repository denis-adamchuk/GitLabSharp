using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single version
   /// </summary>
   public class SingleVersionAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/Versions/1/merge_requests/1/versions/1
      /// </summary>
      internal SingleVersionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this Version instance from Server and de-serialize it
      /// </summary>
      public Task<Entities.Version> LoadTaskAsync()
      {
         return GetTaskAsync<Entities.Version>(BaseUrl);
      }
   }
}

