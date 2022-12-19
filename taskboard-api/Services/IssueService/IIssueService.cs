﻿using Microsoft.AspNetCore.SignalR;
using taskboard_api.DTOs.Issue;

namespace taskboard_api.Services.IssueService
{
    public interface IIssueService
    {
        Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues();
        Task<ServiceResponse<List<GetIssueDTO>>> GetIssuesSubmitted(int userId);
        Task<ServiceResponse<List<GetIssueDTO>>> GetAssignedIssues(int userId);
        Task<ServiceResponse<List<GetIssueDTO>>> GetUnassignedIssues();
        Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id);
        Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO issue, int UserSubmittingId);
        Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO updatedIssue);
        Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int issueId);
    }
}
