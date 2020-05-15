using System;
using System.Text.RegularExpressions;
using System.Net;

namespace GitLabSharp
{
   /// <summary>
   /// Splits merge request url in parts and stores them in properties
   /// <summary>
   public static class UrlParser
   {
      public static readonly string RegEx =
         @"(http[s]?:\/\/)?([^:\/\s]+)\/(api\/v4\/projects\/)?([\w_-]+\/[\w_-]+)\/(?>-\/)?merge_requests\/(\d*)";

      private static readonly Regex url_re = new Regex(RegEx, RegexOptions.Compiled | RegexOptions.IgnoreCase);

      public struct ParsedMergeRequestUrl
      {
         public ParsedMergeRequestUrl(string host, string project, int iid)
         {
            Host = host;
            Project = project;
            IId = iid;
         }

         public string Host { get; }
         public string Project { get; }
         public int IId { get; }
      }

      /// <summary>
      /// Splits passed url in parts and stores in object properties
      /// <summary>
      public static ParsedMergeRequestUrl ParseMergeRequestUrl(string url)
      {
         if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
         {
            throw new UriFormatException("Wrong URL format");
         }

         Match m = url_re.Match(url);
         if (!m.Success)
         {
            throw new UriFormatException("Failed to parse URL");
         }

         if (m.Groups.Count < 4)
         {
            throw new UriFormatException("Unsupported URL format");
         }

         if (!int.TryParse(m.Groups[5].Value, out int iid))
         {
            throw new UriFormatException("Bad IId part of URL");
         }

         return new ParsedMergeRequestUrl(m.Groups[2].Value, m.Groups[4].Value, iid);
      }
   }
}

