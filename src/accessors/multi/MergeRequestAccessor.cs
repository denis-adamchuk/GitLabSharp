using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to a list of project merge requests
   /// </summary>
   public class MergeRequestAccessor : BaseMergeRequestAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/4/merge_requests
      /// </summary>
      internal MergeRequestAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Get access to a single merge request by IId
      /// </summary>
      public SingleMergeRequestAccessor Get(int mergeRequestIId)
      {
         if (mergeRequestIId == 0)
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by zero merge request IId", null);
         }
         return new SingleMergeRequestAccessor(Client, BaseUrl +  "/" + mergeRequestIId.ToString());
      }
   }
}

