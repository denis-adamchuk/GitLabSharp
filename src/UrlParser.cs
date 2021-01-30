using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;

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

      public struct ParsedMergeRequestUrl : IEquatable<ParsedMergeRequestUrl>
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

         public override bool Equals(object obj)
         {
            return obj is ParsedMergeRequestUrl url && Equals(url);
         }

         public bool Equals(ParsedMergeRequestUrl other)
         {
            return Host == other.Host &&
                   Project == other.Project &&
                   IId == other.IId;
         }

         public override int GetHashCode()
         {
            int hashCode = 741791702;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Host);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Project);
            hashCode = hashCode * -1521134295 + IId.GetHashCode();
            return hashCode;
         }
      }

      /// <summary>
      /// Splits passed url in parts and stores in object properties
      /// <summary>
      public static ParsedMergeRequestUrl ParseMergeRequestUrl(string url)
      {
         Match m = url_re.Match(url);
         if (!ifMatchSucceeded(m))
         {
            throw new UriFormatException("Failed to parse URL");
         }
         return new ParsedMergeRequestUrl(m.Groups[2].Value, m.Groups[4].Value, int.Parse(m.Groups[5].Value));
      }

      /// <summary>
      /// Splits passed url in parts and stores in object properties
      /// <summary>
      public static bool Check(string url)
      {
         Match m = url_re.Match(url);
         return ifMatchSucceeded(m);
      }

      private static bool ifMatchSucceeded(Match m)
      {
         return m.Success && m.Groups.Count == 6 && int.TryParse(m.Groups[5].Value, out _);
      }
   }
}

