using System;
using System.Collections.Generic;
using System.Linq;
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
   }

   public struct DiscussionParameters
   {
      public string Body;
      public Position? Position;
   }
}
