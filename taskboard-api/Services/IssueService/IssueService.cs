using AutoMapper;
using Microsoft.EntityFrameworkCore;
using taskboard_api.Data;
using taskboard_api.DTOs.Issue;
using taskboard_api.Models;

namespace taskboard_api.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public IssueService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO newIssue)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            Issue issue = _mapper.Map<Issue>(newIssue);
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
