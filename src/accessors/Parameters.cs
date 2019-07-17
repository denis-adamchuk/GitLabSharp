using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public struct PositionParameters
   {
      public string OldPath;
      public string NewPath;
      public string OldLine;
      public string NewLine;
      public DiffRefs Refs;

      public string ToQueryString()
      {
         string result = String.Empty;
         result += "&" + WebUtility.UrlEncode("position[position_type]") + "=text";
         result += "&" + WebUtility.UrlEncode("position[old_path]") + "=" + WebUtility.UrlEncode(OldPath);
         result += "&" + WebUtility.UrlEncode("position[new_path]") + "=" + WebUtility.UrlEncode(NewPath);
         result += "&" + WebUtility.UrlEncode("position[base_sha]") + "=" + Refs.Base_SHA;
         result += "&" + WebUtility.UrlEncode("position[start_sha]") + "=" + Refs.Start_SHA;
         result += "&" + WebUtility.UrlEncode("position[head_sha]") + "=" + Refs.Head_SHA;
         if (OldLine != null)
         {
            result += "&" + WebUtility.UrlEncode("position[old_line]") + "=" + OldLine;
         }
         if (NewLine != null)
         {
            result += "&" + WebUtility.UrlEncode("position[new_line]") + "=" + NewLine;
         }
         return result;
      }
   }

   /// <summary>
   /// Used to create new discussions
   /// https://docs.gitlab.com/ce/api/discussions.html#create-new-merge-request-thread
   /// </summary>
   public struct DiscussionParameters
   {
      public string Body;
      public PositionParameters? Position;

      public string ToQueryString()
      {
         return "?body=" + WebUtility.UrlEncode(Body) + Position?.ToQueryString() ?? "";
      }
   }

   /// <summary>
   /// Used to modify notes
   /// Warning: 'Resolved' field makes sense for notes that belong to discussions only
   /// https://docs.gitlab.com/ce/api/discussions.html#modify-an-existing-merge-request-thread-note
   /// https://docs.gitlab.com/ce/api/notes.html#modify-existing-merge-request-note 
   /// </summary>
   public class NoteModificationParameters
   {
      public enum ModificationType
      {
         Body,
         Resolved
      }

      public ModificationType Type;
      public string Body;
      public bool Resolved;

      public string ToQueryString()
      {
         switch (Type)
         {
            case NoteModificationParameters.ModificationType.Body:
               return "?body=" + WebUtility.UrlEncode(Body);
            case NoteModificationParameters.ModificationType.Resolved:
               return "?resolved=" + Resolved.ToString();
         }
         return "";
      }
   }
}


