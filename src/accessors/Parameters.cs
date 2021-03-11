using System;
using System.Net;

namespace GitLabSharp.Accessors
{
   public static class QueryStringHelper
   {
      public static string AddQueryParameter(string current, string name, string value)
      {
         if (String.IsNullOrEmpty(current))
         {
            current = "?";
         }
         else
         {
            current += "&";
         }
         return current + String.Format("{0}={1}", name, value);
      }
   }

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
   /// https://docs.gitlab.com/ce/api/notes.html#create-new-merge-request-note
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

   /// <summary>
   /// Used to create merge requests
   /// https://docs.gitlab.com/ee/api/merge_requests.html#create-mr
   /// </summary>
   public struct CreateNewMergeRequestParameters
   {
      public CreateNewMergeRequestParameters(string sourceBranch, string targetBranch, string title,
         int? assigneeId, string description, bool? removeSourceBranch, bool? squash, string[] labels)
      {
         SourceBranch = sourceBranch;
         TargetBranch = targetBranch;
         Title = title;
         AssigneeId = assigneeId;
         Description = description;
         RemoveSourceBranch = removeSourceBranch;
         Squash = squash;
         Labels = labels;
      }

      // required
      public string SourceBranch { get; }
      public string TargetBranch { get; }
      public string Title { get; }

      // optional
      public int? AssigneeId { get; }
      public string Description { get; }
      public bool? RemoveSourceBranch { get; }
      public bool? Squash { get; }
      public string[] Labels { get; }

      public string ToQueryString()
      {
         string result = String.Empty;
         result = QueryStringHelper.AddQueryParameter(result, "source_branch", WebUtility.UrlEncode(SourceBranch));
         result = QueryStringHelper.AddQueryParameter(result, "target_branch", WebUtility.UrlEncode(TargetBranch));
         result = QueryStringHelper.AddQueryParameter(result, "title", WebUtility.UrlEncode(Title.Replace("\r", "")));
         if (AssigneeId.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "assignee_id", AssigneeId.Value.ToString());
         }
         if (!String.IsNullOrEmpty(Description))
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "description", WebUtility.UrlEncode(Description.Replace("\r", "")));
         }
         if (RemoveSourceBranch.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "remove_source_branch", RemoveSourceBranch.ToString().ToLower());
         }
         if (Squash.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "squash", Squash.ToString().ToLower());
         }
         if (Labels != null)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "labels", String.Join(",", Labels).ToLower());
         }
         return result;
      }
   }

   /// <summary>
   /// Used to edit merge requests
   /// https://docs.gitlab.com/ee/api/merge_requests.html#update-mr
   /// </summary>
   public struct UpdateMergeRequestParameters
   {
      public UpdateMergeRequestParameters(string targetBranch, string title,
         int? assigneeId, string description, string stateEvent, bool? removeSourceBranch, bool? squash,
         string[] labels)
      {
         TargetBranch = targetBranch;
         Title = title;
         AssigneeId = assigneeId;
         Description = description;
         StateEvent = stateEvent;
         RemoveSourceBranch = removeSourceBranch;
         Squash = squash;
         Labels = labels;
      }

      public string TargetBranch { get; }
      public string Title { get; }
      public int? AssigneeId { get; }
      public string Description { get; }
      public string StateEvent { get; } // "close" or "reopen"
      public bool? RemoveSourceBranch { get; }
      public bool? Squash { get; }
      public string[] Labels { get; }

      public string ToQueryString()
      {
         string result = String.Empty;
         if (!String.IsNullOrEmpty(TargetBranch))
         {
            result = QueryStringHelper.AddQueryParameter(result, "target_branch", WebUtility.UrlEncode(TargetBranch));
         }
         if (!String.IsNullOrEmpty(Title))
         {
            result = QueryStringHelper.AddQueryParameter(result, "title", WebUtility.UrlEncode(Title.Replace("\r", "")));
         }
         if (AssigneeId.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result, "assignee_id", AssigneeId.Value.ToString());
         }
         if (!String.IsNullOrEmpty(Description))
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "description", WebUtility.UrlEncode(Description.Replace("\r", "")));
         }
         if (!String.IsNullOrEmpty(StateEvent))
         {
            result = QueryStringHelper.AddQueryParameter(result, "state_event", WebUtility.UrlEncode(StateEvent));
         }
         if (RemoveSourceBranch.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "remove_source_branch", RemoveSourceBranch.ToString().ToLower());
         }
         if (Squash.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result, "squash", Squash.ToString().ToLower());
         }
         if (Labels != null)
         {
            result = QueryStringHelper.AddQueryParameter(result, "labels", String.Join(",", Labels).ToLower());
         }
         return result;
      }
   }

   /// <summary>
   /// Used to merge merge requests
   /// https://docs.gitlab.com/ee/api/merge_requests.html#accept-mr
   /// </summary>
   public struct AcceptMergeRequestParameters
   {
      public AcceptMergeRequestParameters(string mergeCommitMessage, string squashCommitMessage,
         bool? squash, bool? shouldRemoveSourceBranch, bool? mergeWhenPipelineSucceeds, string sha)
      {
         MergeCommitMessage = mergeCommitMessage;
         SquashCommitMessage = squashCommitMessage;
         Squash = squash;
         ShouldRemoveSourceBranch = shouldRemoveSourceBranch;
         MergeWhenPipelineSucceeds = mergeWhenPipelineSucceeds;
         Sha = sha;
      }

      public string MergeCommitMessage { get; }
      public string SquashCommitMessage { get; }
      public bool? Squash { get; }
      public bool? ShouldRemoveSourceBranch { get; }
      public bool? MergeWhenPipelineSucceeds { get; }
      public string Sha { get; }

      public string ToQueryString()
      {
         string result = String.Empty;
         if (!String.IsNullOrEmpty(MergeCommitMessage))
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "merge_commit_message", WebUtility.UrlEncode(MergeCommitMessage.Replace("\r", "")));
         }
         if (!String.IsNullOrEmpty(SquashCommitMessage))
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "squash_commit_message", WebUtility.UrlEncode(SquashCommitMessage.Replace("\r", "")));
         }
         if (Squash.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result, "squash", Squash.ToString().ToLower());
         }
         if (ShouldRemoveSourceBranch.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "should_remove_source_branch", ShouldRemoveSourceBranch.ToString().ToLower());
         }
         if (MergeWhenPipelineSucceeds.HasValue)
         {
            result = QueryStringHelper.AddQueryParameter(result,
               "merge_when_pipeline_succeeds", MergeWhenPipelineSucceeds.ToString().ToLower());
         }
         if (!String.IsNullOrEmpty(Sha))
         {
            result = QueryStringHelper.AddQueryParameter(result, "state_event", WebUtility.UrlEncode(Sha));
         }
         return result;
      }
   }
}

