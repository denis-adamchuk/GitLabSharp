using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// A wrapper for WebClient class with separate methods for each of request type (GET/PUT/POST/DELETE)
   /// </summary>
   internal class HttpClient
   {
      internal HttpClient(string host, string token, CancellationTokenSource cts)
      {
         ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
         Client = new WebClient
         {
            BaseAddress = host
         };
         Client.Headers.Add("Content-Type:application/json");
         Client.Headers.Add("Accept:application/json");
         Client.Headers["Private-Token"] = token;

         CancellationTokenSource = cts;
         CancellationTokenSource.Token.Register(Client.CancelAsync);
      }

      internal string Get(string url)
      {
         return Client.DownloadString(url);
      }

      internal Task<string> GetTaskAsync(string url)
      {
         return Client.DownloadStringTaskAsync(url);
      }

      internal string Post(string url)
      {
         return Client.UploadString(url, "POST", "");
      }

      internal Task<string> PostTaskAsync(string url)
      {
         return Client.UploadStringTaskAsync(url, "POST", "");
      }

      internal string Put(string url)
      {
         return Client.UploadString(url, "PUT", "");
      }

      internal Task<string> PutTaskAsync(string url)
      {
         return Client.UploadStringTaskAsync(url, "PUT", "");
      }

      internal string Delete(string url)
      {
         return Client.UploadString(url, "DELETE", "");
      }

      internal Task<string> DeleteTaskAsync(string url)
      {
         return Client.UploadStringTaskAsync(url, "DELETE", "");
      }

      internal void CancelAsync()
      {
         Client.CancelAsync();
      }

      /// <summary>
      /// Collection of Headers for a response on the most recent Http request
      /// </summary>
      internal WebHeaderCollection ResponseHeaders => Client.ResponseHeaders;

      internal CancellationTokenSource CancellationTokenSource { get; };

      private WebClient Client { get; }
   }
}

