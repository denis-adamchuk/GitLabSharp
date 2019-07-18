# GitLabSharp

Object-oriented library for work with GitLab (merge requests primarily)

## Usage example
```
GitLabSharp.GitLab gl = new GitLabSharp.GitLab("https://gitlab-server.com", "access-token");

int id = 1;
GitLabSharp.MergeRequest mr = gl.Projects.Get("group-name/project-name").MergeRequests.Get(id).Load();
Console.WriteLine("Merge-Request with Id {0} has Description \"{1}\"", id, mr.Description);
```
