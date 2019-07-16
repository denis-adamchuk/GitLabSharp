using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   public class SingleNoteAccessor : BaseLoader<Note>
   {
      internal SingleNoteAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      public void Delete()
      {
         throw new NotImplementedException();
      }

      public void Modify()
      {
         throw new NotImplementedException();
      }
   }
}
