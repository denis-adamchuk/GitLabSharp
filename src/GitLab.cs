using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.src
{
   public class GitLab
   {
      public GitLab(string host, string token)
      {
         _httpClient = new HttpClient(host, token);
         _baseUrl = host + "/api/" + "v4";
      }

      public RootAccessor Root()
      {
         return new RootAccessor(_httpClient, _baseUrl);
      }

      private HttpClient _httpClient;
      private string _baseUrl;
   }
}
