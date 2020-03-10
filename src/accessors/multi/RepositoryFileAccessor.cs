using System;
using System.Net;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to repository files
   /// </summary>
   public class RepositoryFileAccessor : BaseMultiAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/projects/5/repository/files
      /// </summary>
      internal RepositoryFileAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Get access to a single file
      /// </summary>
      public SingleRepositoryFileAccessor Get(string filename)
      {
         if (String.IsNullOrWhiteSpace(filename))
         {
            throw new GitLabSharpException(BaseUrl, "Cannot create an accessor by empty file name", null);
         }
         return new SingleRepositoryFileAccessor(Client, BaseUrl + "/" + WebUtility.UrlEncode(filename));
      }
   }
}

