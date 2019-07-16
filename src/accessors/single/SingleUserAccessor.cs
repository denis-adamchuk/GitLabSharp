﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GitLabSharp
{
   /// <summary>
   /// Provides access to information about user
   /// </summary>
   public class SingleUserAccessor : BaseLoader<User>
   {
      internal SingleUserAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about user from Server and de-serializes it
      /// </summary>
      User Details()
      {
         return DoLoad(BaseUrl);
      }
   }
}
