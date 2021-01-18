using System.Net;

namespace GitLabSharp
{
   public struct LibraryContext
   {
      public LibraryContext(int connectionLimit)
      {
         ConnectionLimit = connectionLimit;
      }
      public int ConnectionLimit { get; }
   }

   public static class GitLabSharp
   {
      public static void Initialize(LibraryContext context)
      {
         ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
         ServicePointManager.DefaultConnectionLimit = context.ConnectionLimit;
         ServicePointManager.Expect100Continue = true;
         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      }
   }
}

