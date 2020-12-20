using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr
   /// </summary>
   public class DiffRefs
   {
      [JsonProperty]
      public string Base_SHA { get; protected set; }

      [JsonProperty]
      public string Head_SHA { get; protected set; }

      [JsonProperty]
      public string Start_SHA { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr
   /// </summary>
   public class MergeRequest
   {
      [JsonProperty]
      public int Id { get; protected set; }

      [JsonProperty]
      public int IId { get; protected set; }

      [JsonProperty]
      public string Title { get; protected set; }

      [JsonProperty]
      public string Description { get; protected set; }

      [JsonProperty]
      public string Source_Branch { get; protected set; }

      [JsonProperty]
      public string Target_Branch { get; protected set; }

      [JsonProperty]
      public string State { get; protected set; }

      [JsonProperty]
      public IEnumerable<string> Labels { get; protected set; }

      [JsonProperty]
      public string Web_Url { get; protected set; }

      [JsonProperty]
      public bool Work_In_Progress { get; protected set; }

      [JsonProperty]
      public User Author { get; protected set; }

      [JsonProperty]
      public DateTime Created_At { get; protected set; }

      [JsonProperty]
      public DateTime Updated_At { get; protected set; }

      [JsonProperty]
      public int Project_Id { get; protected set; }

      [JsonProperty]
      public bool Squash { get; protected set; }

      [JsonProperty]
      public bool? Should_Remove_Source_Branch { get; protected set; }

      [JsonProperty]
      public bool Force_Remove_Source_Branch { get; protected set; }

      [JsonProperty]
      public User Assignee { get; protected set; }

      [JsonProperty]
      public bool? Rebase_In_Progress { get; protected set; }

      [JsonProperty]
      public string Merge_Error { get; protected set; }

      [JsonProperty]
      public string Merge_Status { get; protected set; }

      [JsonProperty]
      public bool Has_Conflicts { get; protected set; }

      [JsonProperty]
      public bool Blocking_Discussions_Resolved { get; protected set; }

      [JsonProperty]
      public string Sha { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#rebase-a-merge-request
   /// </summary>
   public class MergeRequestRebaseResponse
   {
      [JsonProperty]
      public bool Rebase_In_Progress { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#add-spent-time-for-a-merge-request
   /// </summary>
   public class SpentTime
   {
      [JsonProperty]
      public string Human_Time_Estimate { get; protected set; }

      [JsonProperty]
      public string Human_Total_Time_Spent { get; protected set; }

      [JsonProperty]
      public int Time_Estimate { get; protected set; }

      [JsonProperty]
      public int Total_Time_Spent { get; protected set; }
   }
}
