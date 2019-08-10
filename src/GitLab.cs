﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to GitLab API requests
   /// </summary>
   public class GitLab : IDisposable
   {
      internal GitLab(string host, string token)
      {
         CancellationTokenSource = new CancellationTokenSource();
         Client = new HttpClient(host, token, CancellationTokenSource);
         BaseUrl = host + "/api/" + "v4";
      }

      /// <summary>
      /// Dispose the object
      /// </summary>
      internal void Dispose()
      {
         CancellationTokenSource.Dispose();
      }

      /// <summary>
      /// Get access to information about current user
      /// </summary>
      public SingleUserAccessor CurrentUser => new SingleUserAccessor(Client, BaseUrl + "/user");

      /// <summary>
      /// Get access to list of projects hosted at this server
      /// </summary>
      /// <returns></returns>
      public ProjectAccessor Projects => new ProjectAccessor(Client, BaseUrl + "/projects");

      internal CancellationTokenSource CancellationTokenSource { get; }

      private HttpClient Client { get; }
      private string BaseUrl { get; }
   }
}

