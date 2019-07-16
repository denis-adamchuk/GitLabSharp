using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public class VersionsAccessor : BaseLoader<List<Version>>
   {
      internal VersionsAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }
   }
}

