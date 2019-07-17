using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// A wrapper for WebClient class with separate methods for each of request type (GET/PUT/POST/DELETE)
   /// </summary>
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

      /// <summary>
      /// Collection of Headers for a response on the most recent Http request
      /// </summary>
      internal WebHeaderCollection ResponseHeaders => _client.ResponseHeaders;

      private readonly WebClient _client;
   }
}
