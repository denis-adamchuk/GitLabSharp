using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-a-single-mr-diff-version
   /// </summary>
   public class DiffStruct
   {
      [JsonProperty]
      public string Old_Path { get; protected set; }

      [JsonProperty]
      public string New_Path { get; protected set; }

      [JsonProperty]
      public bool New_File { get; protected set; }

      [JsonProperty]
      public bool Renamed_File { get; protected set; }

      [JsonProperty]
      public bool Deleted_File { get; protected set; }

      [JsonProperty]
      public string Diff { get; protected set; }
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-mr-diff-versions
   /// </summary>
   public class Version
   {
      public Version(int id, string base_Commit_SHA, string head_Commit_SHA, string start_Commit_SHA,
         DateTime created_At, IEnumerable<DiffStruct> diffs, IEnumerable<Commit> commits)
      {
         Id = id;
         Base_Commit_SHA = base_Commit_SHA;
         Head_Commit_SHA = head_Commit_SHA;
         Start_Commit_SHA = start_Commit_SHA;
         Created_At = created_At;
         Diffs = diffs;
         Commits = commits;
      }

      [JsonProperty]
      public int Id { get; protected set; }

      [JsonProperty]
      public string Base_Commit_SHA { get; protected set; }

      [JsonProperty]
      public string Head_Commit_SHA { get; protected set; }

      [JsonProperty]
      public string Start_Commit_SHA { get; protected set; }

      [JsonProperty]
      public DateTime Created_At { get; protected set; }

      [JsonProperty]
      public IEnumerable<DiffStruct> Diffs { get; protected set; }

      [JsonProperty]
      public IEnumerable<Commit> Commits { get; protected set; }
   }
}
