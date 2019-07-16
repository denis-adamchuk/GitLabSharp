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
         HttpClient = new HttpClient(host, token);
         BaseUrl = host + "/api/" + "v4";
      }

      public RootAccessor Root()
      {
         return new RootAccessor(HttpClient, BaseUrl);
      }

      private HttpClient HttpClient;
      private string BaseUrl;
   }
}
