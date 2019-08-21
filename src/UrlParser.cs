using System;
using System.Text.RegularExpressions;
using System.Net;

namespace GitLabSharp
{
   /// <summary>
   /// Splits merge request url in parts and stores them in properties
   /// <summary>
   public class ParsedMergeRequestUrl
   {
      private static readonly Regex url_re = new Regex(
         @"^(http[s]?:\/\/[^:\/\s]+)\/(api\/v4\/projects\/)?(\w+\/\w+)\/merge_requests\/(\d*)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

      /// <summary>
      /// Throws:
      /// UriFormatException if parsing failed
      /// <summary>
      public ParsedMergeRequestUrl(string url)
      {
         parse(url);
      }

      /// <summary>
      /// Splits passed url in parts and stores in object properties
      /// <summary>
      private void parse(string url)
      {
         if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
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

         Host = m.Groups[1].Value;
         Project = m.Groups[3].Value;
         if (!int.TryParse(m.Groups[4].Value, out int id))
         {
            throw new UriFormatException("Bad IId part of URL");
         }
         IId = id;
      }

      public string Host { get; private set; }
      public string Project { get; private set; }
      public int IId { get; private set; }
   }
}

