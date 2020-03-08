using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Part of NewDiscussionParameters
   /// https://docs.gitlab.com/ce/api/discussions.html#create-new-merge-request-thread
   /// </summary>
   public struct PositionParameters
   {
      public string OldPath { get; set; }
      public string NewPath { get; set; }
      public string OldLine { get; set; }
      public string NewLine { get; set; }
      public string BaseSHA { get; set; }
      public string HeadSHA { get; set; }
      public string StartSHA { get; set; }

      public string ToQueryString()
      {
         string result = String.Empty;
         result += WebUtility.UrlEncode("position[position_type]") + "=text";
         result += "&" + WebUtility.UrlEncode("position[old_path]") + "=" + WebUtility.UrlEncode(OldPath);
         result += "&" + WebUtility.UrlEncode("position[new_path]") + "=" + WebUtility.UrlEncode(NewPath);
         result += "&" + WebUtility.UrlEncode("position[base_sha]") + "=" + BaseSHA;
         result += "&" + WebUtility.UrlEncode("position[start_sha]") + "=" + StartSHA;
         result += "&" + WebUtility.UrlEncode("position[head_sha]") + "=" + HeadSHA;
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
   public struct NewDiscussionParameters
   {
      public string Body { get; set; }
      public PositionParameters? Position { get; set; }

      public string ToQueryString()
      {
         string body = Body.Replace("\r", "");
         return "body=" + WebUtility.UrlEncode(body) + "&" + (Position?.ToQueryString() ?? "");
      }
   }

   /// <summary>
   /// Used to create notes
   /// https://docs.gitlab.com/ce/api/notes.html#modify-existing-merge-request-note 
   /// </summary>
   public class CreateNewNoteParameters
   {
      public string Body { get; set; }

      public string ToQueryString()
      {
         string body = Body.Replace("\r", "");
         return "body=" + WebUtility.UrlEncode(body);
      }
   }

   /// <summary>
   /// Used to resolve/un-resolve discussion threads
   /// </summary>
   public class ResolveThreadParameters
   {
      public bool Resolve { get; set; }

      public string ToQueryString()
      {
         return "resolved=" + Resolve.ToString().ToLower();
      }
   }

   /// <summary>
   /// Used to modify notes
   /// https://docs.gitlab.com/ce/api/notes.html#modify-existing-merge-request-note 
   /// </summary>
   public class ModifyNoteParameters
   {
      public string Body { get; set; }

      public string ToQueryString()
      {
         string body = Body.Replace("\r", "");
         return "body=" + WebUtility.UrlEncode(body);
      }
   }

   /// <summary>
   /// Used to modify discussion notes
   /// https://docs.gitlab.com/ce/api/discussions.html#modify-an-existing-merge-request-thread-note
   /// </summary>
   public class ModifyDiscussionNoteParameters
   {
      public enum ModificationType
      {
         Body,
         Resolved
      }

      public ModificationType Type { get; set; }
      public string Body { get; set; }
      public bool Resolved { get; set; }

      public string ToQueryString()
      {
         switch (Type)
         {
            case ModificationType.Body:
               {
                  string body = Body.Replace("\r", "");
                  return "body=" + WebUtility.UrlEncode(body);
               }
            case ModificationType.Resolved:
               return "resolved=" + Resolved.ToString().ToLower();
         }
         return "";
      }
   }

   /// <summary>
   /// Used to add/subtract spent time to merge request
   /// </summary>
   public class AddSpentTimeParameters
   {
      public bool Add { get; set; }
      public TimeSpan Span { get; set; }

      public string ToQueryString()
      {
         string duration = Span.ToString("hh") + "h" + Span.ToString("mm") + "m" + Span.ToString("ss") + "s";
         return "duration=" + (Add ? "" : "-") + duration;
      }
   }

   /// <summary>
   /// Used to compare branches, tags or commits
   /// </summary>
   public class CompareParameters
   {
      public string From;
      public string To;

      public string ToQueryString()
      {
         return String.Format("from={0}&to={1}", WebUtility.UrlEncode(From), WebUtility.UrlEncode(To));
      }
   }
}

