using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_request_approvals.html#get-configuration-1
   /// </summary>
   public class MergeRequestApprovalConfiguration
   {
      [JsonProperty]
      public string Id { get; protected set; }

      [JsonProperty]
      public string IId { get; protected set; }

      [JsonProperty]
      public string Project_Id { get; protected set; }

      [JsonProperty]
      public string Title { get; protected set; }

      [JsonProperty]
      public string Description { get; protected set; }

      [JsonProperty]
      public string State { get; protected set; }

      [JsonProperty]
      public DateTime Created_At { get; protected set; }

      [JsonProperty]
      public DateTime Updated_At { get; protected set; }

      [JsonProperty]
      public string Merge_Status { get; protected set; }

      [JsonProperty]
      public int Approvals_Required { get; protected set; }

      [JsonProperty]
      public int Approvals_Left { get; protected set; }

      [JsonProperty]
      public IEnumerable<User> Approved_By { get; protected set; }
   }
}

