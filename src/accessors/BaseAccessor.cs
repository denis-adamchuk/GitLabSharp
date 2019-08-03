﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Exception class for non-specific issues.
   /// </summary>
   public class GitLabSharpException : Exception
   {
      public GitLabSharpException(string url, string error)
         : base(String.Format("Error occurred with URL \"{0}\": {1}", url, error))
      {
      }
   }

   /// <summary>
   /// Exception class for System.Net.WebException class of issues.
   /// </summary>
   public class GitLabRequestException : Exception
   {
      public GitLabRequestException(string url, string method, System.Net.WebException webException)
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
         return Serializer.Deserialize<T>(safeRequest(url, "GET"));
      }

      /// <summary>
      /// Execute Http GET request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> GetTaskAsync<T>(string url)
      {
         return Serializer.Deserialize<T>(await requestTaskAsync(url, "GET"));
      }

      /// <summary>
      /// Execute Http POST request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Post<T>(string url)
      {
         return Serializer.Deserialize<T>(safeRequest(url, "POST"));
      }

      /// <summary>
      /// Execute Http POST request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> PostTaskAsync<T>(string url)
      {
         return Serializer.Deserialize<T>(await requestTaskAsync(url, "POST"));
      }

      /// <summary>
      /// Execute Http PUT request and de-serialize a response into a new T object instance
      /// </summary>
      internal T Put<T>(string url)
      {
         return Serializer.Deserialize<T>(safeRequest(url, "PUT"));
      }

      /// <summary>
      /// Execute Http PUT request asynchronously and de-serialize a response into a new T object instance
      /// </summary>
      async internal Task<T> PutTaskAsync<T>(string url)
      {
         return Serializer.Deserialize<T>(await requestTaskAsync(url, "PUT"));
      }

      /// <summary>
      /// Execute Http DELETE request
      /// </summary>
      internal void Delete(string url)
      {
         safeRequest(url, "DELETE");
      }

      /// <summary>
      /// Execute Http DELETE request asynchronously
      /// </summary>
      async internal Task DeleteTaskAsync(string url)
      {
         await requestTaskAsync(url, "DELETE");
      }

      // TODO Get rid of copy/paste below

      /// <summary>
      /// Executes a request but converts System.Net.WebException into GitLabSharpException
      /// </summary>
      protected string safeRequest(string url, string method)
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
      /// Executes a request but converts System.Net.WebException into GitLabSharpException
      /// </summary>
      protected Task<string> requestTaskAsync(string url, string method)
      {
         if (method == "GET")
         {
            return Client.GetTaskAsync(url);
         }
         else if (method == "POST")
         {
            return Client.PostTaskAsync(url);
         }
         else if (method == "PUT")
         {
            return Client.PutTaskAsync(url);
         }
         else if (method == "DELETE")
         {
            return Client.DeleteTaskAsync(url);
         }
         else
         {
            Debug.Assert(false);
         }
         return null;
      }

      protected JavaScriptSerializer Serializer = new JavaScriptSerializer();
      internal HttpClient Client { get; }
      internal string BaseUrl { get; }
   }
}

