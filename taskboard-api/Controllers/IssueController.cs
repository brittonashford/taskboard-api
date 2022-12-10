using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskboard_api.DTOs.Issue;
using taskboard_api.Models;
using taskboard_api.Services.IssueService;

namespace taskboard_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _characterService;

        public IssueController(IIssueService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAllIssues")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> GetAllIssues()
        {
            return Ok(await _characterService.GetAllIssues());
        }

        [HttpGet("GetIssueById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetIssueDTO>>> GetIssueById(int id)
        {
            return Ok(await _characterService.GetIssueById(id));
        }

        [HttpPost("CreateIssue")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> AddIssue(AddIssueDTO newIssue)
        {
            return Ok(await _characterService.AddIssue(newIssue));
        }

    }
}
