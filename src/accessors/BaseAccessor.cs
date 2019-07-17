using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Base class for all Accessors
   /// </summary>
   public class BaseAccessor<T>
   {
      internal BaseAccessor(HttpClient client, string baseUrl)
      {
         HttpClient = client;
         BaseUrl = baseUrl;
      }

      /// <summary>
      /// Execute Http GET request and de-serialize a response into a new T object instance
      /// </summary>
      protected T DoLoad(string url)
      {
         JavaScriptSerializer s = new JavaScriptSerializer();
         return s.Deserialize<T>(HttpClient.Get(url));
      }

      internal HttpClient HttpClient { get; }
      protected string BaseUrl { get; }
   }
}
