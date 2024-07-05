using System;
using System.Threading.Tasks;
using GitLabSharp.Entities;

namespace GitLabSharp.Accessors
{
   /// <summary>
   /// Provides access to information about personal access token
   /// </summary>
   public class SinglePersonalAccessTokenAccessor : BaseAccessor
   {
      /// <summary>
      /// baseUrl example: https://gitlab.example.com/api/v4/personal_access_tokens/self
      /// </summary>
      internal SinglePersonalAccessTokenAccessor(HttpClient client, string baseUrl) : base(client, baseUrl)
      {
      }

      /// <summary>
      /// Loads information about personal access token from Server and de-serializes it
      /// </summary>
      public Task<PersonalAccessToken> LoadTaskAsync()
      {
         return GetTaskAsync<PersonalAccessToken>(BaseUrl);
      }

      public Task<PersonalAccessToken> RotateTaskAsync(string expiresAt)
      {
         string suffix = String.IsNullOrEmpty(expiresAt) ? "" : ("?expires_at=" + expiresAt);
         return PostTaskAsync<PersonalAccessToken>(BaseUrl + "/rotate" + suffix);
      }
   }
}
