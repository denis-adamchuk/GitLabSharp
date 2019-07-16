using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class BaseLoader<T> : BaseAccessor
   {
      internal BaseLoader(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public T Load()
      {
         JavaScriptSerializer s = new JavaScriptSerializer();
         return s.Deserialize<T>(_httpClient.Get(_baseUrl));
      }
   }
}
