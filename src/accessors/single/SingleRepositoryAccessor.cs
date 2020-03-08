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
   /// Provides access to git repository
   /// </summary>
   public class SingleRepositoryAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/repository
      /// </summary>
      internal SingleRepositoryAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Compare branches, tags or commits
      /// </summary>
      public Task<Comparison> CompareAsync(CompareParameters parameters)
      {
         return GetTaskAsync<Comparison>(BaseUrl + "/compare?" + parameters.ToQueryString());
      }
   }
}

