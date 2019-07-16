using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabSharp
{
   public struct DiffRefs
   {
      public string BaseSHA;
      public string HeadSHA;
      public string StartSHA;
   }

   public struct Position
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
         result += "&" + WebUtility.UrlEncode("position[base_sha]") + "=" + Refs.BaseSHA;
         result += "&" + WebUtility.UrlEncode("position[start_sha]") + "=" + Refs.StartSHA;
         result += "&" + WebUtility.UrlEncode("position[head_sha]") + "=" + Refs.HeadSHA;
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
}
