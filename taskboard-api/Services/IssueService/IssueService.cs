using AutoMapper;
using Microsoft.EntityFrameworkCore;
using taskboard_api.Data;
using taskboard_api.DTOs.Issue;
using taskboard_api.DTOs.User;
using taskboard_api.Models;

namespace taskboard_api.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IAuthRepository _authRepo;

        public IssueService(IMapper mapper, DataContext context, IAuthRepository authRepo)
        {
            _mapper = mapper;
            _context = context;
            _authRepo = authRepo;
        }
        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO newIssue, int submittedBy)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var submittingResponse = new ServiceResponse<User>();
            var assignedResponse = new ServiceResponse<User>();
            //Issue issue = _mapper.Map<Issue>(newIssue);

            submittingResponse = await _authRepo.GetUser(submittedBy);
            User userSubmitting = submittingResponse.Data;
            User userAssignedTo = null;

            if (newIssue.AssignedToId != null)
            {
                assignedResponse = await _authRepo.GetUser((int)newIssue.AssignedToId);
                userAssignedTo = assignedResponse.Data;
            }
            
            Issue issue = new Issue()
            {
                Title = newIssue.Title,
                Type = newIssue.Type,
                Priority = newIssue.Priority,
                Status = newIssue.Status,
                Description = newIssue.Description,
                SubmittedBy = userSubmitting,
                AssignedTo = userAssignedTo
            };

            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Issues
                .Select(i => _mapper.Map<GetIssueDTO>(i)).ToListAsync(); 
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int issueId)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();

            try
            {
                Issue issue = await _context.Issues.FirstAsync(i => i.IssueId == issueId);
                _context.Issues.Remove(issue);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetIssuesSubmitted(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues
                .Where(c => c.SubmittedBy.Id == userId)
                .ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetAssignedIssues(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues
                .Where(c => c.AssignedTo.Id == userId)
                .ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues()
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues.ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id)
        {
            var serviceResponse = new ServiceResponse<GetIssueDTO>();
            var dbIssue = await _context.Issues.FirstOrDefaultAsync(i => i.IssueId == id);
            serviceResponse.Data = _mapper.Map<GetIssueDTO>(dbIssue);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            var serviceResponse = new ServiceResponse<GetIssueDTO>();

            try
            {
                var issue = await _context.Issues
                    .FirstOrDefaultAsync(i => i.IssueId == updatedIssue.IssueId);

                _mapper.Map(updatedIssue, issue);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetIssueDTO>(issue);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
