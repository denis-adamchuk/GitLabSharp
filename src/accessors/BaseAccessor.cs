using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Base class for all Accessors - classes, that run Http Requests to access different kinds of data
   /// </summary>
   public class BaseAccessor
   {
      internal BaseAccessor(HttpClient client, string baseUrl)
      {
         Client = client;
         BaseUrl = baseUrl;
      }

      /// <summary>
      /// Execute Http GET request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Get<T>(string url)
      {
         return Serializer.Deserialize<T>(Client.Get(url));
      }

      /// <summary>
      /// Execute Http POST request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Post<T>(string url)
      {
         return Serializer.Deserialize<T>(Client.Post(url));
      }

      /// <summary>
      /// Execute Http PUT request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Put<T>(string url)
      {
         return Serializer.Deserialize<T>(Client.Put(url));
      }

      /// <summary>
      /// Execute Http DELETE request
      /// </summary>
      internal void Delete(string url)
      {
         Client.Delete(url);
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

      protected JavaScriptSerializer Serializer = new JavaScriptSerializer();
      internal HttpClient Client { get; }
      protected string BaseUrl { get; }
   }
}
