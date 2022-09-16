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
   public class HttpClient : IDisposable
   {
      /// <summary>
      /// Throws ArgumentException when host name is invalid
      /// </summary>
      public HttpClient(string host, CancellationTokenSource cts)
      {
         Client = new WebClient
         {
            BaseAddress = host,
            Encoding = Encoding.UTF8
         };
         Client.Headers.Add("Content-Type", "application/json");
         Client.Headers.Add("Accept", "application/json");

         CancellationTokenSource = cts;
         CancellationTokenSource.Token.Register(() => Client?.CancelAsync());
      }

      public void Dispose()
      {
         Client?.Dispose();
         Client = null;
      }

      public string Host => Client?.BaseAddress;

      public string Get(string url)
      {
         return Client?.DownloadString(url);
      }

      public Task<string> GetTaskAsync(string url)
      {
         return TimeoutAfter(Client?.DownloadStringTaskAsync(url), AsyncOperationTimeOut, onTimeout);
      }

      public Task<byte[]> GetDataTaskAsync(string url)
      {
         return TimeoutAfter(Client?.DownloadDataTaskAsync(url), AsyncOperationTimeOut, onTimeout);
      }

      public string Post(string url)
      {
         return Client?.UploadString(url, "POST", "");
      }

      public Task<string> PostTaskAsync(string url)
      {
         return TimeoutAfter(Client?.UploadStringTaskAsync(url, "POST", ""), AsyncOperationTimeOut, onTimeout);
      }

      public string Put(string url)
      {
         return Client?.UploadString(url, "PUT", "");
      }

      public Task<string> PutTaskAsync(string url)
      {
         return TimeoutAfter(Client?.UploadStringTaskAsync(url, "PUT", ""), AsyncOperationTimeOut, onTimeout);
      }

      public string Delete(string url)
      {
         return Client?.UploadString(url, "DELETE", "");
      }

      public Task<string> DeleteTaskAsync(string url)
      {
         return TimeoutAfter(Client?.UploadStringTaskAsync(url, "DELETE", ""), AsyncOperationTimeOut, onTimeout);
      }

      private void onTimeout()
      {
         Client?.CancelAsync();
         throw new TimeoutException("HTTP async operation timed out.");
      }

      async private static Task<T> TimeoutAfter<T>(Task<T> task, int millisecondsDelay, Action OnTimeout)
      {
         await Task.WhenAny(task, Task.Delay(millisecondsDelay));
         if (!task.IsCompleted)
         {
            OnTimeout?.Invoke();
         }
         return await task;
      }

      private int AsyncOperationTimeOut => GitLabSharp.AsyncOperationTimeOut;

      /// <summary>
      /// Collection of Headers for a response on the most recent Http request
      /// </summary>
      public WebHeaderCollection ResponseHeaders => Client?.ResponseHeaders;

      public CancellationTokenSource CancellationTokenSource { get; }

      protected WebClient Client;
   }
}

