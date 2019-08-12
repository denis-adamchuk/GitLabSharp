﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of projects
   /// </summary>
   public class ProjectAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects
      /// </summary>
      internal ProjectAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of projects from Server and de-serialize it
      /// </summary>
      public List<Project> Load(ProjectsFilter filter, PageFilter pageFilter)
      {
         return Get<List<Project>>(BaseUrl + "?" + filter.ToQueryString() + "&" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it
      /// </summary>
      public List<Project> LoadAll(ProjectsFilter filter)
      {
         return GetAll<List<Project>, Project>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Load full list of discussions from Server and de-serialize it (async)
      /// </summary>
      public Task<List<Project>> LoadAllTaskAsync(ProjectsFilter filter)
      {
         return GetAllTaskAsync<List<Project>, Project>(BaseUrl + "?" + filter.ToQueryString() + "&");
      }

      /// <summary>
      /// Get number of projects taking into account the filter
      /// </summary>
      public int Count(ProjectsFilter filter)
      {
         return Count(BaseUrl + "?" + filter.ToQueryString());
      }

      /// <summary>
      /// Get access to a single project
      /// </summary>
      public SingleProjectAccessor Get(string projectId)
      {
         return new SingleProjectAccessor(Client, BaseUrl + "/" + WebUtility.UrlEncode(projectId));
      }
   }
}
