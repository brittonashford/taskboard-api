using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using taskboard_api.Data;



namespace taskboard_api.Repositories.IssueStatus
{
    public class IssueStatusRepo : IIssueStatusRepo
    {
        private readonly DataContext _context;

        public IssueStatusRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Models.IssueStatus>>> GetAvailableStatuses(int userRoleId, int laneId)
        {
            if (userRoleId == 0 || userRoleId == null || laneId == 0 || laneId == null)
            {
                throw new Exception($"Parameter missing. userRoleId: {userRoleId}, laneId: {laneId}.");
            }

            var serviceResponse = new ServiceResponse<List<Models.IssueStatus>>();
            var availableStatusIds = await _context.AvailableStatuses
                .Where(a => a.UserRoleId == userRoleId && a.LaneId == laneId)
                .Select(a => a.IssueStatusId)
                .ToListAsync();

            if(availableStatusIds.IsNullOrEmpty())
            {
                throw new Exception($"No available Issue Statuses for userRoleId: {userRoleId}, laneId: {laneId}.");
            }

            var availableStatuses = await _context.IssueStatuses
                .Where(i => availableStatusIds.Contains(i.IssueStatusId))
                .ToListAsync();

            if(availableStatuses.IsNullOrEmpty())
            {
                throw new Exception($"No available Issue Statuses for userRoleId: {userRoleId}, laneId: {laneId}.");
            }

            serviceResponse.Data = availableStatuses;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Models.IssueStatus>> GetIssueStatusById(int issueStatusID)
        {
            var serviceResponse = new ServiceResponse<Models.IssueStatus>();
            var issueStatus = await _context.IssueStatuses
                .FirstOrDefaultAsync(i => i.IssueStatusId == issueStatusID);

            if (issueStatus == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Issue Status not found";
            }
            else
            {
                serviceResponse.Data = issueStatus;
            }

            return serviceResponse;
        }
    }
}
