using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of notes
   /// </summary>
   public class NoteAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/merge_requests/11/notes
      /// </summary>
      internal NoteAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load a single page from a full list of notes from Server and de-serialize it
      /// </summary>
      public IEnumerable<Note> Load(PageFilter pageFilter)
      {
         return Get<IEnumerable<Note>>(BaseUrl + "?" + pageFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of notes from Server and de-serialize it
      /// </summary>
      public IEnumerable<Note> LoadAll()
      {
         return GetAll<Note>(BaseUrl + "?");
      }

      /// <summary>
      /// Load list of notes from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Note>> LoadTaskAsync(PageFilter pageFilter, SortFilter sortFilter)
      {
         return GetTaskAsync<IEnumerable<Note>>(BaseUrl + "?" + pageFilter.ToQueryString()
                                                 + "&" + sortFilter.ToQueryString());
      }

      /// <summary>
      /// Load list of notes and total count of notes from Server and de-serialize it (async)
      /// </summary>
      public Task<Tuple<IEnumerable<Note>, int>> LoadAndCalculateTotalCountAsync(
         PageFilter pageFilter, SortFilter sortFilter)
      {
         return GetAndCalculateCountTaskAsync<IEnumerable<Note>>(
            BaseUrl + "?" + pageFilter.ToQueryString() + "&" + sortFilter.ToQueryString());
      }

      /// <summary>
      /// Load full list of notes from Server and de-serialize it (async)
      /// </summary>
      public Task<IEnumerable<Note>> LoadAllTaskAsync()
      {
         return GetAllTaskAsync<Note>(BaseUrl + "?");
      }

      /// <summary>
      /// Get number of notes
      /// Note: PageFilter is ignored
      /// </summary>
      public int Count()
      {
         return Count(BaseUrl);
      }

      /// <summary>
      /// Get number of notes (async)
      /// Note: PageFilter is ignored
      /// </summary>
      public Task<int> CountAsync()
      {
         return CountTaskAsync(BaseUrl);
      }

      /// <summary>
      /// Get access to a single note by Id
      /// </summary>
      public SingleNoteAccessor Get(int noteId)
      {
         if (noteId == 0)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by zero note Id", null);
         }
         return new SingleNoteAccessor(Client, BaseUrl + "/" + noteId.ToString());
      }

      /// <summary>
      /// Create a new note with given body
      /// </summary>
      public Note CreateNew(CreateNewNoteParameters parameters)
      {
         return Post<Note>(BaseUrl + "?" + parameters.ToQueryString());
      }

      /// <summary>
      /// Create a new note with given body (async)
      /// </summary>
      public Task<Note> CreateNewTaskAsync(CreateNewNoteParameters parameters)
      {
         return PostTaskAsync<Note>(BaseUrl + "?" + parameters.ToQueryString());
      }
   }
}

