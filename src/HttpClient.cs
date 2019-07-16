using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   internal class HttpClient
   {
      internal HttpClient(string host, string token)
      {
         ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
         _client = new WebClient
         {
            BaseAddress = host
         };
         _client.Headers.Add("Content-Type:application/json");
         _client.Headers.Add("Accept:application/json");
         _client.Headers["Private-Token"] = token;
      }

      internal string Get(string url)
      {
         return _client.DownloadString(url);
      }

      internal string Post(string url)
      {
         return _client.UploadString(url, "POST", "");
      }

      internal string Put(string url)
      {
         return _client.UploadString(url, "PUT", "");
      }

      internal string Delete(string url)
      {
         return _client.UploadString(url, "DELETE", "");
      }

      private readonly WebClient _client;
   }
}
