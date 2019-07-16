﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to a single discussion
   /// </summary>
   public class SingleDiscussionAccessor : BaseLoader<Discussion>
   {
      internal SingleDiscussionAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Load information about this discussion instance from Server and de-serialize it
      /// </summary>
      Discussion Details()
      {
         return DoLoad(BaseUrl);
      }
   }
}
