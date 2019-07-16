using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Loads data from HttpClient and de-serializes it into T object instance
   /// </summary>
   public class BaseLoader<T> : BaseAccessor
   {
      internal BaseLoader(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      protected T DoLoad(string url)
      {
         JavaScriptSerializer s = new JavaScriptSerializer();
         return s.Deserialize<T>(HttpClient.Get(url));
      }
   }
}
