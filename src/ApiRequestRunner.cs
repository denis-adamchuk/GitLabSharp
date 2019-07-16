//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GitLabSharp
//{
//   internal class ApiRequestRunner
//   {
//      internal enum RequestType
//      {
//         Get,
//         Post,
//         Put,
//         Delete
//      }

//      internal ApiRequestRunner(ConnectionInfo connectionInfo)
//      {
//         _processor = new HttpClient(connectionInfo);
//      }

//      internal Dictionary<string, object> Run(string url, RequestType type)
//      {
//         string response = String.Empty;
//         switch (type)
//         {
//            case RequestType.Get:
//               response = _processor.Get(url);
//               break;

//            case RequestType.Post:
//               response = _processor.Post(url);
//               break;

//            case RequestType.Put:
//               response = _processor.Put(url);
//               break;

//            case RequestType.Delete:
//               response = _processor.Delete(url);
//               break;
//         }
//         // TODO
//         return new Dictionary<string, object>();
//      }

//      HttpClient _processor;

//   }
//}
