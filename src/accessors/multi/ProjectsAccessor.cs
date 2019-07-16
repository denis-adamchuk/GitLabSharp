using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class ProjectsAccessor : BaseLoader<List<Project>>
   {
      internal ProjectsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public SingleProjectAccessor Single(string projectId)
      {
         return new SingleProjectAccessor(_httpClient, _baseUrl + "/" + projectId);
      }
   }
}
