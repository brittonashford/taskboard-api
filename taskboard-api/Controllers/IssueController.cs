using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Issue>> GetAllIssues()
        {
            return Ok(_characterService.GetAllIssues());
        }

        [HttpGet("GetIssueById/{id}")]
        public ActionResult<Issue> GetIssueById(int id)
        {
            return Ok(_characterService.GetIssueById(id));
        }

        [HttpPost("CreateIssue")]
        public ActionResult<List<Issue>> AddIssue(Issue newIssue)
        {
            return Ok(_characterService.AddIssue(newIssue));
        }

    }
}
