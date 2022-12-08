namespace taskboard_api.Services.IssueService
{
    public interface IIssueService
    {
        List<Issue> GetAllIssues();
        Issue GetIssueById(int id);
        List<Issue> AddIssue(Issue issue);
    }
}
