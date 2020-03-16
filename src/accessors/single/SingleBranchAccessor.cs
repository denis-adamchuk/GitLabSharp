using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a single Branch instance
   /// </summary>
   public class SingleBranchAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/repository/branches/NAME
      /// </summary>
      internal SingleBranchAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Delete Branch
      /// </summary>
      async public Task<bool> DeleteTaskAsync()
      {
         await base.DeleteTaskAsync(BaseUrl);
         return true;
      }
   }
}

