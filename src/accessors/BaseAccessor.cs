using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class BaseAccessor
   {
      internal BaseAccessor(HttpClient client, string baseUrl)
      {
         _httpClient = client;
         _baseUrl = baseUrl;
      }

      internal HttpClient _httpClient;
      protected string _baseUrl;
   }
}
