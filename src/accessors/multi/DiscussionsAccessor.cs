using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class DiscussionsAccessor : BaseLoader<List<Discussion>>
   {
      internal DiscussionsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public SingleDiscussionAccessor Single(string discussionId)
      {
         return new SingleDiscussionAccessor(_httpClient, _baseUrl + "/" + discussionId);
      }

      public void New(DiscussionParameters parameters)
      {
         throw new NotImplementedException();
      }
   }
}
