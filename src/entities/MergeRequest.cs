using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Entities
{
   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr
   /// </summary>
   public struct DiffRefs
   {
      public string Base_SHA;
      public string Head_SHA;
      public string Start_SHA;
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#get-single-mr
   /// </summary>
   public struct MergeRequest
   {
      public int Id;
      public int IId;
      public string Title;
      public string Description;
      public string Source_Branch;
      public string Target_Branch;
      public string State;
      public IEnumerable<string> Labels;
      public string Web_Url;
      public bool Work_In_Progress;
      public User Author;
      public DiffRefs Diff_Refs;
      public DateTime Created_At;
      public DateTime Updated_At;
      public int Project_Id;

      public override int GetHashCode()
      {
         return Id.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if (obj is MergeRequest mr)
         {
            return mr.Id == Id;
         }
         return false;
      }
   }

   /// <summary>
   /// https://docs.gitlab.com/ce/api/merge_requests.html#add-spent-time-for-a-merge-request
   /// </summary>
   public struct SpentTime
   {
      public string Human_Time_Estimate;
      public string Human_Total_Time_Spent;
      public int Time_Estimate;
      public int Total_Time_Spent;
   }
}
