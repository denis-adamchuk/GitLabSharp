using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// A wrapper for WebClient class with separate methods for each of request type (GET/PUT/POST/DELETE)
   /// </summary>
   internal class HttpClient : IDisposable
   {
      /// <summary>
      /// Throws ArgumentException when host name is invalid
      /// </summary>
      internal HttpClient(string host, string token, CancellationTokenSource cts)
      {
         Client = new WebClient
         {
            BaseAddress = host,
            Encoding = Encoding.UTF8
         };
         Client.Headers.Add("Content-Type", "application/json");
         Client.Headers.Add("Accept", "application/json");
         Client.Headers.Add("Private-Token", token);

         CancellationTokenSource = cts;
         CancellationTokenSource.Token.Register(() => Client?.CancelAsync());
      }

      public void Dispose()
      {
         Client?.Dispose();
         Client = null;
      }

      public string Host => Client?.BaseAddress;

      internal string Get(string url)
      {
         return Client?.DownloadString(url);
      }

      internal Task<string> GetTaskAsync(string url)
      {
         return TimeoutAfter(Client?.DownloadStringTaskAsync(url), AsyncOperationTimeOut, onTimeout);
      }

      internal string Post(string url)
      {
         return Client?.UploadString(url, "POST", "");
      }

      internal Task<string> PostTaskAsync(string url)
      {
         return TimeoutAfter(Client?.UploadStringTaskAsync(url, "POST", ""), AsyncOperationTimeOut, onTimeout);
      }

      internal string Put(string url)
      {
         return Client?.UploadString(url, "PUT", "");
      }

      internal Task<string> PutTaskAsync(string url)
      {
         return TimeoutAfter(Client?.UploadStringTaskAsync(url, "PUT", ""), AsyncOperationTimeOut, onTimeout);
      }

      internal string Delete(string url)
      {
         return Client?.UploadString(url, "DELETE", "");
      }

      internal Task<string> DeleteTaskAsync(string url)
      {
         return TimeoutAfter(Client?.UploadStringTaskAsync(url, "DELETE", ""), AsyncOperationTimeOut, onTimeout);
      }

      private void onTimeout()
      {
         Client?.CancelAsync();
         throw new TimeoutException("HTTP async operation timed out.");
      }

      private static readonly int AsyncOperationTimeOut = 60 * 1000; // 60 sec

      async private static Task<T> TimeoutAfter<T>(Task<T> task, int millisecondsDelay, Action OnTimeout)
      {
         await Task.WhenAny(task, Task.Delay(millisecondsDelay));
         if (!task.IsCompleted)
         {
            OnTimeout?.Invoke();
         }
         return await task;
      }

      /// <summary>
      /// Collection of Headers for a response on the most recent Http request
      /// </summary>
      internal WebHeaderCollection ResponseHeaders => Client?.ResponseHeaders;

      internal CancellationTokenSource CancellationTokenSource { get; }

      private WebClient Client;
   }
}

