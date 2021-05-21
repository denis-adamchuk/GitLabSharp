using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GitLabSharp.Utils;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Exception class for System.Net.WebException class of issues.
   /// </summary>
   public class GitLabRequestException : ExceptionEx
   {
      internal GitLabRequestException(string url, string method, Exception innerException)
         : base(String.Format("GitLab returned error on requesting URL \"{0}\" with method {1}", url, method),
            innerException)
      {
      }
   }

   /// <summary>
   /// Base class for all Accessors - classes, that run Http Requests to access different kinds of data
   /// </summary>
   public class BaseAccessor
   {
      internal BaseAccessor(HttpClient client, string baseUrl)
      {
         Client = client;
         BaseUrl = baseUrl;
         TraceRequests = false;
      }

      /// <summary>
      /// Should Trace.TraceInformation() be called for each HTTP request
      /// </summary>
      public bool TraceRequests { get; set; }

      /// <summary>
      /// Execute Http GET request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> GetTaskAsync<T>(string url)
      {
         return await makeRequestAndDeserializeResponseAsync<T>(url, "GET");
      }

      /// <summary>
      /// Execute Http POST request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> PostTaskAsync<T>(string url)
      {
         return await makeRequestAndDeserializeResponseAsync<T>(url, "POST");
      }

      /// <summary>
      /// Execute Http PUT request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> PutTaskAsync<T>(string url)
      {
         return await makeRequestAndDeserializeResponseAsync<T>(url, "PUT");
      }

      /// <summary>
      /// Execute Http DELETE request asynchronously
      /// </summary>
      internal Task DeleteTaskAsync(string url)
      {
         return makeRequestAsync(url, "DELETE");
      }

      async protected Task<T> makeRequestAndDeserializeResponseAsync<T>(string url, string method)
      {
         string jsonResponse = await makeRequestAsync(url, method);
         if (jsonResponse == String.Empty)
         {
            // in very rare/exceptional cases JSON response is empty on first attempt
            jsonResponse = await makeRequestAsync(url, method);
         }

         if (jsonResponse == null)
         {
            throw new GitLabSharpException(url,
               String.Format("JSON response of {0} method is null", method), null);
         }

         T result;
         try
         {
            result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonResponse,
               new Newtonsoft.Json.JsonSerializerSettings
               {
                  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
               });
         }
         catch (Exception ex) // Any exception from JsonConvert.DeserializeObject()
         {
            throw new GitLabSharpException(url,
               String.Format("Cannot deserialize JSON response of {0} method", method), ex);
         }

         if (result == null) //-V3111
         {
            throw new GitLabSharpException(url,
               String.Format("Cannot deserialize JSON response of {0} method ({1}) into object of type {2}",
               method, jsonResponse, typeof(T).FullName), null);
         }
         return result;
      }

      /// <summary>
      /// Executes an asynchronous request but converts System.Net.WebException into GitLabRequestException
      /// </summary>
      async protected Task<string> makeRequestAsync(string url, string method)
      {
         string response = String.Empty;
         try
         {
            if (TraceRequests) Trace.TraceInformation("{0} {1}", method, url);
            if (method == "GET")
            {
               response = await Client.GetTaskAsync(url);
            }
            else if (method == "POST")
            {
               response = await Client.PostTaskAsync(url);
            }
            else if (method == "PUT")
            {
               response = await Client.PutTaskAsync(url);
            }
            else if (method == "DELETE")
            {
               response = await Client.DeleteTaskAsync(url);
            }
            else
            {
               Debug.Assert(false);
            }

            // if even an I/O completed, user might have requested its cancellation
            Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
         }
         catch (System.Net.WebException ex)
         {
            if (ex.Status == System.Net.WebExceptionStatus.RequestCanceled)
            {
               throw new OperationCanceledException();
            }
            else
            {
               // if even an I/O failed, user might have requested its cancellation
               Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            throw new GitLabRequestException(url, method, ex);
         }
         catch (TimeoutException ex)
         {
            // if even an I/O timed out, user might have requested its cancellation
            Client.CancellationTokenSource.Token.ThrowIfCancellationRequested();
            throw new GitLabRequestException(url, method, ex);
         }
         return response;
      }

      internal HttpClient Client { get; }
      protected string BaseUrl { get; }
   }
}

