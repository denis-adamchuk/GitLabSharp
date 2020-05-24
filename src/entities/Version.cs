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

      public override bool Equals(object obj)
      {
         return obj is DiffStruct @struct &&
                Old_Path == @struct.Old_Path &&
                New_Path == @struct.New_Path &&
                New_File == @struct.New_File &&
                Renamed_File == @struct.Renamed_File &&
                Deleted_File == @struct.Deleted_File &&
                Diff == @struct.Diff;
      }

      public override int GetHashCode()
      {
         int hashCode = 439609276;
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Old_Path);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(New_Path);
         hashCode = hashCode * -1521134295 + New_File.GetHashCode();
         hashCode = hashCode * -1521134295 + Renamed_File.GetHashCode();
         hashCode = hashCode * -1521134295 + Deleted_File.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Diff);
         return hashCode;
      }
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
      public IEnumerable<Commit> Commits { get; protected set; }

      public override bool Equals(object obj)
      {
         return obj is Version version &&
                Id == version.Id &&
                Base_Commit_SHA == version.Base_Commit_SHA &&
                Head_Commit_SHA == version.Head_Commit_SHA &&
                Start_Commit_SHA == version.Start_Commit_SHA &&
                Created_At == version.Created_At &&
                EqualityComparer<IEnumerable<DiffStruct>>.Default.Equals(Diffs, version.Diffs) &&
                EqualityComparer<IEnumerable<Commit>>.Default.Equals(Commits, version.Commits);
      }

      public override int GetHashCode()
      {
         int hashCode = 1862810366;
         hashCode = hashCode * -1521134295 + Id.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Base_Commit_SHA);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Head_Commit_SHA);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Start_Commit_SHA);
         hashCode = hashCode * -1521134295 + Created_At.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<DiffStruct>>.Default.GetHashCode(Diffs);
         hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Commit>>.Default.GetHashCode(Commits);
         return hashCode;
      }
   }
}
