using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskboard_api.Data;
using taskboard_api.DTOs.Issue;
using taskboard_api.Models;
using taskboard_api.Services.IssueService;

namespace taskboard_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService characterService)
        {
            _issueService = characterService;
        }

        [HttpGet("GetAllIssues")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> GetAllIssues()
        {
            return Ok(await _issueService.GetAllIssues());
        }

        [HttpGet("GetIssueById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetIssueDTO>>> GetIssueById(int id)
        {
            return Ok(await _issueService.GetIssueById(id));
        }

        [HttpPost("CreateIssue")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> AddIssue(AddIssueDTO newIssue)
        {
            return Ok(await _issueService.AddIssue(newIssue));
        }

        [HttpPut("UpdateIssue")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            var serviceResponse = await _issueService.UpdateIssue(updatedIssue);

            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("DeleteIssue/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> DeleteIssue(int id)
        {
            var serviceResponse = await _issueService.DeleteIssue(id);

            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

    }
}
