using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI
{
   public class Project
   {
      public Project(Root root, string id)
      {
         Root = root;
         Id = id;
      }

      public MergeRequests MergeRequests()
      {
         return new MergeRequests(Root, Id);
      }

      public string Id { get; }

      private Root Root { get; }
   }
}
