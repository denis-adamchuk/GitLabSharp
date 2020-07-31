using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

      public override bool Equals(object obj)
      {
         return obj is DiffRefs refs &&
                Base_SHA == refs.Base_SHA &&
                Head_SHA == refs.Head_SHA &&
                Start_SHA == refs.Start_SHA;
      }

      public override int GetHashCode()
      {
         int hashCode = 1263814533;
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Base_SHA);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Head_SHA);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Start_SHA);
         return hashCode;
      }
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
      public DiffRefs Diff_Refs { get; protected set; }

      [JsonProperty]
      public DateTime Created_At { get; protected set; }

      [JsonProperty]
      public DateTime Updated_At { get; protected set; }

      [JsonProperty]
      public int Project_Id { get; protected set; }

      [JsonProperty]
      public bool Squash { get; protected set; }

      [JsonProperty]
      public bool Should_Remove_Source_Branch { get; protected set; }

      [JsonProperty]
      public User Assignee { get; protected set; }

      public override bool Equals(object obj)
      {
         return obj is MergeRequest request &&
                Id == request.Id &&
                IId == request.IId &&
                Title == request.Title &&
                Description == request.Description &&
                Source_Branch == request.Source_Branch &&
                Target_Branch == request.Target_Branch &&
                State == request.State &&
                EqualityComparer<IEnumerable<string>>.Default.Equals(Labels, request.Labels) &&
                Web_Url == request.Web_Url &&
                Work_In_Progress == request.Work_In_Progress &&
                EqualityComparer<User>.Default.Equals(Author, request.Author) &&
                EqualityComparer<DiffRefs>.Default.Equals(Diff_Refs, request.Diff_Refs) &&
                Created_At == request.Created_At &&
                Updated_At == request.Updated_At &&
                Project_Id == request.Project_Id;
      }

      public override int GetHashCode()
      {
         int hashCode = -371336302;
         hashCode = hashCode * -1521134295 + Id.GetHashCode();
         hashCode = hashCode * -1521134295 + IId.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Source_Branch);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Target_Branch);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(State);
         hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<string>>.Default.GetHashCode(Labels);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Web_Url);
         hashCode = hashCode * -1521134295 + Work_In_Progress.GetHashCode();
         hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(Author);
         hashCode = hashCode * -1521134295 + EqualityComparer<DiffRefs>.Default.GetHashCode(Diff_Refs);
         hashCode = hashCode * -1521134295 + Created_At.GetHashCode();
         hashCode = hashCode * -1521134295 + Updated_At.GetHashCode();
         hashCode = hashCode * -1521134295 + Project_Id.GetHashCode();
         return hashCode;
      }
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

      public override bool Equals(object obj)
      {
         return obj is SpentTime time &&
                Human_Time_Estimate == time.Human_Time_Estimate &&
                Human_Total_Time_Spent == time.Human_Total_Time_Spent &&
                Time_Estimate == time.Time_Estimate &&
                Total_Time_Spent == time.Total_Time_Spent;
      }

      public override int GetHashCode()
      {
         int hashCode = 1258033978;
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Human_Time_Estimate);
         hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Human_Total_Time_Spent);
         hashCode = hashCode * -1521134295 + Time_Estimate.GetHashCode();
         hashCode = hashCode * -1521134295 + Total_Time_Spent.GetHashCode();
         return hashCode;
      }
   }
}
