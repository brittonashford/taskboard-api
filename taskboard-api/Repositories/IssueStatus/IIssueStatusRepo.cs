namespace taskboard_api.Repositories.IssueStatus
{
    public interface IIssueStatusRepo
    {
        Task<ServiceResponse<Models.IssueStatus>> GetIssueStatusById(int issueStatusID);
        Task<ServiceResponse<List<Models.IssueStatus>>> GetAvailableStatuses(int userRoleId, int laneId);
    }
}
