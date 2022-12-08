namespace taskboard_api.Services.IssueService
{
    public interface IIssueService
    {
        Task<ServiceResponse<List<Issue>>> GetAllIssues();
        Task<ServiceResponse<Issue>> GetIssueById(int id);
        Task<ServiceResponse<List<Issue>>> AddIssue(Issue issue);
    }
}
