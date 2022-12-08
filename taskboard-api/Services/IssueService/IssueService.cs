using taskboard_api.Models;

namespace taskboard_api.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private static List<Issue> issues = new List<Issue>
        {
            new Issue
            {
                IssueId = 1,
                Title = "Test1"
            },
            new Issue
            {
                IssueId = 2,
                Title = "Test2"
            }
        };
        public async Task<ServiceResponse<List<Issue>>> AddIssue(Issue newIssue)
        {
            var serviceResponse = new ServiceResponse<List<Issue>>();
            issues.Add(newIssue);
            serviceResponse.Data = issues;  
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Issue>>> GetAllIssues()
        {
            var serviceResponse = new ServiceResponse<List<Issue>>();
            serviceResponse.Data = issues;  
            return serviceResponse;
        }

        public async Task<ServiceResponse<Issue>> GetIssueById(int id)
        {
            var serviceResponse = new ServiceResponse<Issue>();
            serviceResponse.Data = issues.FirstOrDefault(i => i.IssueId == id);
            return serviceResponse;
        }
    }
}
