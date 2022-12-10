using taskboard_api.DTOs.Issue;

namespace taskboard_api.Services.IssueService
{
    public interface IIssueService
    {
        Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues();
        Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id);
        Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO issue);
    }
}
