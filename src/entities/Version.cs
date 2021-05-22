using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
      public IEnumerable<Commit> Commits { get; set; }

      [JsonProperty]
      public string State { get; set; }
   }
}
