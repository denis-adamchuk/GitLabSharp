namespace GitLabSharp
{
   internal class GitLabHttpClient : HttpClient
   {
      internal GitLabHttpClient(string host, string token, System.Threading.CancellationTokenSource cts)
         : base(host, cts)
      {
         Client.Headers.Add("Private-Token", token);
      }
   }
}

