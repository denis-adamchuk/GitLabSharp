using System;
using System.Net;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Part of NewDiscussionParameters
   /// https://docs.gitlab.com/ce/api/discussions.html#create-new-merge-request-thread
   /// </summary>
   public struct PositionParameters
   {
      public PositionParameters(string oldPath, string newPath, string oldLine, string newLine,
         string baseSHA, string headSHA, string startSHA)
      {
         OldPath = oldPath;
         NewPath = newPath;
         OldLine = oldLine;
         NewLine = newLine;
         BaseSHA = baseSHA;
         HeadSHA = headSHA;
         StartSHA = startSHA;
      }

      public string OldPath { get; }
      public string NewPath { get; }
      public string OldLine { get; }
      public string NewLine { get; }
      public string BaseSHA { get; }
      public string HeadSHA { get; }
      public string StartSHA { get; }

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
      public NewDiscussionParameters(string body, PositionParameters? position)
      {
         Body = body;
         Position = position;
      }

      public string Body { get; }
      public PositionParameters? Position { get; }

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
   public struct CreateNewNoteParameters
   {
      public CreateNewNoteParameters(string body)
      {
         Body = body;
      }

      public string Body { get; }

      public string ToQueryString()
      {
         string body = Body.Replace("\r", "");
         return "body=" + WebUtility.UrlEncode(body);
      }
   }

   /// <summary>
   /// Used to resolve/un-resolve discussion threads
   /// </summary>
   public struct ResolveThreadParameters
   {
      public ResolveThreadParameters(bool resolve)
      {
         Resolve = resolve;
      }

      public bool Resolve { get; }

      public string ToQueryString()
      {
         return "resolved=" + Resolve.ToString().ToLower();
      }
   }

   /// <summary>
   /// Used to modify notes
   /// https://docs.gitlab.com/ce/api/notes.html#modify-existing-merge-request-note
   /// </summary>
   public struct ModifyNoteParameters
   {
      public ModifyNoteParameters(string body)
      {
         Body = body;
      }

      public string Body { get; }

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
   public struct ModifyDiscussionNoteParameters
   {
      public ModifyDiscussionNoteParameters(ModificationType type, string body, bool resolved)
      {
         Type = type;
         Body = body;
         Resolved = resolved;
      }

      public enum ModificationType
      {
         Body,
         Resolved
      }

      public ModificationType Type { get; }
      public string Body { get; }
      public bool Resolved { get; }

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
   public struct AddSpentTimeParameters
   {
      public AddSpentTimeParameters(bool add, TimeSpan span)
      {
         Add = add;
         Span = span;
      }

      public bool Add { get; }
      public TimeSpan Span { get; }

      public string ToQueryString()
      {
         string duration = Span.ToString("hh") + "h" + Span.ToString("mm") + "m" + Span.ToString("ss") + "s";
         return "duration=" + (Add ? "" : "-") + duration;
      }
   }

   /// <summary>
   /// Used to compare branches, tags or commits
   /// </summary>
   public struct CompareParameters
   {
      public CompareParameters(string from, string to)
      {
         From = from;
         To = to;
      }

      public string From { get; }
      public string To { get; }

      public string ToQueryString()
      {
         return String.Format("from={0}&to={1}&straight=true", WebUtility.UrlEncode(From), WebUtility.UrlEncode(To));
      }
   }

   /// <summary>
   /// Used to create branches in the repository
   /// </summary>
   public struct CreateNewBranchParameters
   {
      public CreateNewBranchParameters(string name, string sha)
      {
         Name = name;
         Ref = sha;
      }

      public string Name { get; }
      public string Ref { get; }

      public string ToQueryString()
      {
         return String.Format("branch={0}&ref={1}", WebUtility.UrlEncode(Name), WebUtility.UrlEncode(Ref));
      }
   }
}

