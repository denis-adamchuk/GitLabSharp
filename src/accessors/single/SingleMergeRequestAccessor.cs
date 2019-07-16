using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class SingleMergeRequestAccessor : BaseLoader<MergeRequest>
   {
      internal SingleMergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public VersionsAccessor Versions()
      {
         return new VersionsAccessor(_httpClient, _baseUrl + "/versions");
      }

      public DiscussionsAccessor Discussions()
      {
         return new DiscussionsAccessor(_httpClient, _baseUrl + "/discussions");
      }

      public NotesAccessor Notes()
      {
         return new NotesAccessor(_httpClient, _baseUrl + "/notes");
      }

      public void AddSpentTime(TimeSpan timeSpan)
      {
         throw new NotImplementedException();
      }
   }
}
