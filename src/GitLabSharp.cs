using System.Net;

namespace GitLabSharp
{
   public struct LibraryContext
   {
      public LibraryContext(int connectionLimit, int asyncOperationTimeoutSeconds)
      {
         ConnectionLimit = connectionLimit;
         AsyncOperationTimeoutSeconds = asyncOperationTimeoutSeconds;
      }

      public int ConnectionLimit { get; }

      public int AsyncOperationTimeoutSeconds { get; }
   }

   public static class GitLabSharp
   {
      public static void Initialize(LibraryContext context)
      {
         ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
         ServicePointManager.DefaultConnectionLimit = context.ConnectionLimit;
         ServicePointManager.Expect100Continue = true;
         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

         _asyncOperationTimeoutMilliseconds = context.AsyncOperationTimeoutSeconds * 1000;
      }

      internal static int AsyncOperationTimeOut => _asyncOperationTimeoutMilliseconds;

      private static readonly int DefaultAsyncOperationTimeOut = 60 * 1000; // 60 sec
      private static int _asyncOperationTimeoutMilliseconds = DefaultAsyncOperationTimeOut;
   }
}

