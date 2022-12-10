using AutoMapper;
using taskboard_api.DTOs.Issue;
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
        private readonly IMapper _mapper;

        public IssueService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO newIssue)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            Issue issue = _mapper.Map<Issue>(newIssue);
            issue.IssueId = issues.Max(c => c.IssueId) + 1;
            issues.Add(issue);
            serviceResponse.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();  
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues()
        {
            return new ServiceResponse<List<GetIssueDTO>>
            {
                Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList()
            };
        }

        public async Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id)
        {
            var serviceResponse = new ServiceResponse<GetIssueDTO>();
            var issue = issues.FirstOrDefault(i => i.IssueId == id);
            serviceResponse.Data = _mapper.Map<GetIssueDTO>(issue);
            return serviceResponse;
        }
    }
}
