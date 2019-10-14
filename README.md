# GitLabSharp

Object-oriented library for work with GitLab (merge requests primarily)

## Description
This library was developed as a backend for https://github.com/denis-adamchuk/mrHelper application.
It does not support everything that is available via GitLab API but only a subset related to Merge Requests.

## Usage example
```
async private Task PrintCommitsAsync()
{
   string host = "https://gitlab-server.com";
   string token = "access-token";
   
   string project = "group-name/project-name";
   int iid = 1;
   
   List<Commit> commits = await GetCommitsAsync(host, token, project, iid);
   Console.WriteLine("Merge-Request with IId {0} has {1} commits", iid, commits.Count);
}

async private Task<List<Commit>> GetCommitsAsync(string host, string token, string projectName, int iid)
{
   GitLabClient Client = new GitLabClient(host, token);

   try
   {
      return (List<Commit>)(await Client.RunAsync(async (gitlab) =>
         await gitlab.Projects.Get(projectName).MergeRequests.Get(iid).Commits.LoadAllTaskAsync()));
   }
   catch (Exception ex)
   {
      Debug.Assert(ex is GitLabSharpException
                || ex is GitLabRequestException
                || ex is GitLabClientCancelled);
      throw;
   }
}
```
