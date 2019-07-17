using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a single merge request instance
   /// </summary>
   public class SingleMergeRequestAccessor : BaseLoader<MergeRequest>
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/4/merge_requests/1
      /// </summary>
      internal SingleMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this merge request from Server and de-serialize it
      /// </summary>
      public MergeRequest Load()
      {
         return DoLoad(BaseUrl);
      }

      /// <summary>
      /// Get access to a list of versions of this merge request
      /// </summary>
      public VersionsAccessor Versions => new VersionsAccessor(HttpClient, BaseUrl + "/versions");

      /// <summary>
      /// Get access to a list of discussions of this merge request
      /// </summary>
      public DiscussionsAccessor Discussions => new DiscussionsAccessor(HttpClient, BaseUrl + "/discussions");

      /// <summary>
      /// Get access to a list of notes of this merge request
      /// </summary>
      public NotesAccessor Notes => new NotesAccessor(HttpClient, BaseUrl + "/notes");

      /// <summary>
      /// Add spent time to the merge request of this merge request
      /// </summary>
      public void AddSpentTime(TimeSpan span)
      {
         string duration = span.ToString("hh") + "h" + span.ToString("mm") + "m" + span.ToString("ss") + "s";
         string url = BaseUrl + "/add_time_spent?duration=" + duration;
         HttpClient.Post(url);
      }
   }
}
