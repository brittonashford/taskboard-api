using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using taskboard_api.Data;
using taskboard_api.DTOs.Issue;
using taskboard_api.DTOs.User;
using taskboard_api.DTOs.UserRole;
using taskboard_api.Models;
using taskboard_api.Repositories.Auth;
using taskboard_api.Repositories.IssueStatus;

namespace taskboard_api.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IAuthRepository _authRepo;
        private readonly IIssueStatusRepo _issueStatusRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IssueService(IMapper mapper, DataContext context, IAuthRepository authRepo, IIssueStatusRepo issueStatusRepo, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _authRepo = authRepo;
            _issueStatusRepo = issueStatusRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetCurrentUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        private async Task<bool> IsValidUserId(int Id)
        {
            if (await _context.Users.AnyAsync(u => u.Id == Id))
            {
                return true;
            }
            return false;
        }
        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO newIssue, int submittedBy)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            try
            {
                var issue = _mapper.Map<Issue>(newIssue);
                var submittedById = GetCurrentUserId();

                if (submittedById > 0)
                {
                    issue.SubmittedById = submittedById;
                }
                else
                {
                    throw new Exception("Unable to find UserId for current user");
                }

                //TODO: fix bug
                // if AssignedToId = 0, a FK error will occur. C# ints aren't nullabe, but SQL Server allows it...
                if ((newIssue.AssignedToId != null && await IsValidUserId((int)newIssue.AssignedToId)) || newIssue.AssignedToId == null)
                {
                    issue.AssignedToId = newIssue.AssignedToId;
                }
                else
                {
                    throw new Exception("Unable to add new issue. Assigned to invalid user.");
                }

                issue.LastUpdatedById = GetCurrentUserId();
                issue.LastUpdatedDate = DateTime.Now;

                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();

                //returns list of all of the user's issues
                serviceResponse.Data =
                    await _context.Issues
                    .Where(i => i.SubmittedById == GetCurrentUserId())
                    .Select(i => _mapper.Map<GetIssueDTO>(i))
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int issueId)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            //TODO: add logic for PM and Admin (delete anything)
            try
            {
                var issue = await _context.Issues
                    .FirstOrDefaultAsync(i => i.IssueId == issueId && i.SubmittedById == GetCurrentUserId());

                if (issue is null)
                {
                    throw new Exception($"Issue not found. IssueId: {issueId}.");
                }

                _context.Issues.Remove(issue);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Issues
                    .Where(i => i.SubmittedById == GetCurrentUserId())
                    .Select(i => _mapper.Map<GetIssueDTO>(i)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetIssuesSubmitted()
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues
                .Where(c => c.SubmittedById == GetCurrentUserId())
                .ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetAssignedIssues(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues
                .Where(c => c.AssignedToId == userId)
                .ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetUnassignedIssues()
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues
                .Where(c => c.AssignedToId == null)
                .ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues()
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            var dbIssues = await _context.Issues
                    .Include(i => i.SubmittedBy)
                    .Include(i => i.AssignedTo)
                    .ToListAsync();
            serviceResponse.Data = dbIssues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id)
        {
            var serviceResponse = new ServiceResponse<GetIssueDTO>();
            var dbIssue = await _context.Issues.FirstOrDefaultAsync(i => i.IssueId == id);

            //....only retrieve issue if user submitted it
            //var dbIssue = await _context.Issues
            //    .FirstOrDefaultAsync(i => i.IssueId == id && i.SubmittedBy.Id == GetCurrentUserId());

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

                if (issue is null)
                {
                    throw new Exception($"Issue not found. IssueId: {updatedIssue.IssueId}");
                }

                var issueStatus = await _issueStatusRepo.GetIssueStatusById(updatedIssue.IssueStatusId);
                if (issueStatus == null)
                {
                    throw new Exception($"Issue status not found for IssueStatusId: {updatedIssue.IssueStatusId}.");
                }
                
                issue.Title = updatedIssue.Title;
                issue.Type = updatedIssue.Type;
                issue.Priority = updatedIssue.Priority;
                issue.Status = issueStatus.Data;
                issue.Description = updatedIssue.Description;
                issue.AssignedToId = updatedIssue.AssignedToId;
                issue.LastUpdatedById = GetCurrentUserId();
                issue.LastUpdatedDate = DateTime.Now;

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
