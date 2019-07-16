using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Base class for all Accessors
   /// </summary>
   public class BaseAccessor
   {
      internal BaseAccessor(HttpClient client, string baseUrl)
      {
         HttpClient = client;
         BaseUrl = baseUrl;
      }

      internal HttpClient HttpClient { get; }
      protected string BaseUrl { get; }
   }
}
