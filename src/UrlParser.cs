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
      private static readonly Regex url_re = new Regex(
         @"^(http[s]?:\/\/)?([^:\/\s]+)\/(api\/v4\/projects\/)?(\w+\/\w+)\/merge_requests\/(\d*)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

      public struct ParsedMergeRequestUrl
      {
         public string Host;
         public string Project;
         public int IId;
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
            throw new UriFormatException("Failed");
         }

         if (m.Groups.Count < 4)
         {
            throw new UriFormatException("Unsupported URL format");
         }

         if (!int.TryParse(m.Groups[5].Value, out int id))
         {
            throw new UriFormatException("Bad IId part of URL");
         }

         return new ParsedMergeRequestUrl
         {
            Host = m.Groups[2].Value,
            Project = m.Groups[4].Value,
            IId = id
         };
      }
   }
}

