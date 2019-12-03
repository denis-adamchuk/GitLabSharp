using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Exception class for System.Net.WebException class of issues.
   /// </summary>
   public class GitLabRequestException : Exception
   {
      internal GitLabRequestException(string url, string method, System.Net.WebException webException)
         : base(String.Format("GitLab returned error on requesting URL \"{0}\" with method {1}", url, method))
      {
         WebException = webException;
      }

      public System.Net.WebException WebException { get; }
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
      }

      /// <summary>
      /// Execute Http GET request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Get<T>(string url)
      {
         return makeRequestAndDeserializeResponse<T>(url, "GET");
      }

      /// <summary>
      /// Execute Http GET request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> GetTaskAsync<T>(string url)
      {
         return await makeRequestAndDeserializeResponseAsync<T>(url, "GET");
      }

      /// <summary>
      /// Execute Http POST request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Post<T>(string url)
      {
         return makeRequestAndDeserializeResponse<T>(url, "POST");
      }

      /// <summary>
      /// Execute Http POST request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> PostTaskAsync<T>(string url)
      {
         return await makeRequestAndDeserializeResponseAsync<T>(url, "POST");
      }

      /// <summary>
      /// Execute Http PUT request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Put<T>(string url)
      {
         return makeRequestAndDeserializeResponse<T>(url, "PUT");
      }

      /// <summary>
      /// Execute Http PUT request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> PutTaskAsync<T>(string url)
      {
         return await makeRequestAndDeserializeResponseAsync<T>(url, "PUT");
      }

      /// <summary>
      /// Execute Http DELETE request
      /// </summary>
      internal void Delete(string url)
      {
         makeRequest(url, "DELETE");
      }

      /// <summary>
      /// Execute Http DELETE request asynchronously
      /// </summary>
      internal Task DeleteTaskAsync(string url)
      {
         return makeRequestAsync(url, "DELETE");
      }

      /// <summary>
      /// Execute a request and de-serialize JSON response
      /// </summary>
      protected T makeRequestAndDeserializeResponse<T>(string url, string method)
      {
         string r = makeRequest(url, method);

         try
         {
            return Serializer.Deserialize<T>(r);
         }
         catch (Exception ex) // whatever deserialization Exception
         {
            throw new GitLabSharpException(url,
               String.Format("Cannot deserialize JSON response of {0} method", method), ex);
         }
      }

      async protected Task<T> makeRequestAndDeserializeResponseAsync<T>(string url, string method)
      {
         string r = await makeRequestAsync(url, method);

         try
         {
            return Serializer.Deserialize<T>(r);
         }
         catch (Exception ex) // whatever deserialization Exception
         {
            throw new GitLabSharpException(url,
               String.Format("Cannot deserialize JSON response of {0} method", method), ex);
         }
      }

      /// <summary>
      /// Executes a request but converts System.Net.WebException into GitLabRequestException
      /// </summary>
      protected string makeRequest(string url, string method)
      {
         string response = String.Empty;
         try
         {
            if (method == "GET")
            {
               response = Client.Get(url);
            }
            else if (method == "POST")
            {
               response = Client.Post(url);
            }
            else if (method == "PUT")
            {
               response = Client.Put(url);
            }
            else if (method == "DELETE")
            {
               response = Client.Delete(url);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         catch (System.Net.WebException ex)
         {
            throw new GitLabRequestException(url, method, ex);
         }
         return response;
      }

      /// <summary>
      /// Executes an asynchronous request but converts System.Net.WebException into GitLabRequestException
      /// </summary>
      async protected Task<string> makeRequestAsync(string url, string method)
      {
         string response = String.Empty;
         try
         {
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
               response  = await Client.PutTaskAsync(url);
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
         return response;
      }

      private static int DefaultMaxJsonLength = 2097152; // from the documentation
      private static int MaxJsonLengthMultiplier = 10;

      protected JavaScriptSerializer Serializer = new JavaScriptSerializer()
      {
         MaxJsonLength = DefaultMaxJsonLength * MaxJsonLengthMultiplier
      };
      internal HttpClient Client { get; }
      protected string BaseUrl { get; }
   }
}

