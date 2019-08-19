﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single discussion. GitLab's discussion includes all its discussion notes.
   /// Note, this class does not provide access to individual notes within a discussion for their deletion or modification. 
   /// NoteAccessor can be easily used for this purpose.
   /// </summary>
   public class SingleDiscussionAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/discussions/1
      /// </summary>
      internal SingleDiscussionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this discussion instance from Server and de-serialize it
      /// </summary>
      public Discussion Load()
      {
         return Get<Discussion>(BaseUrl);
      }

      /// <summary>
      /// Load information about this discussion instance from Server and de-serialize it
      /// </summary>
      public Task<Discussion> LoadTaskAsync()
      {
         return GetTaskAsync<Discussion>(BaseUrl);
      }

      /// <summary>
      /// Resolve/un-resolve a discussion thread
      /// </summary>
      public Discussion Resolve(ResolveThreadParameters parameters)
      {
         return Put<Discussion>(BaseUrl + "?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Resolve/un-resolve a discussion thread
      /// </summary>
      public Task<Discussion> ResolveTaskAsync(ResolveThreadParameters parameters)
      {
         return PutTaskAsync<Discussion>(BaseUrl + "?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Create a new note within this discussion
      /// </summary>
      public DiscussionNote CreateNewNote(CreateNewNoteParameters parameters)
      {
         return Post<DiscussionNote>(BaseUrl + "/notes?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Create a new note within this discussion
      /// </summary>
      public Task<DiscussionNote> CreateNewNoteTaskAsync(CreateNewNoteParameters parameters)
      {
         return PostTaskAsync<DiscussionNote>(BaseUrl + "/notes?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Modify discussion note
      /// </summary>
      public DiscussionNote ModifyNote(int noteId, ModifyDiscussionNoteParameters parameters)
      {
         return Put<DiscussionNote>(BaseUrl + "/notes/" + noteId.ToString() + "?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Modify discussion note
      /// </summary>
      public Task<DiscussionNote> ModifyNoteTaskAsync(int noteId, ModifyDiscussionNoteParameters parameters)
      {
         return PutTaskAsync<DiscussionNote>(BaseUrl + "/notes/" + noteId.ToString() + "?" + parameters.ToQueryString());
      }
   }
}

