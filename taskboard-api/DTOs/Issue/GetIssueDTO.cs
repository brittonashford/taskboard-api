using taskboard_api.DTOs.User;

namespace taskboard_api.DTOs.Issue
{
    public class GetIssueDTO
    {
        public int IssueId { get; set; }
        public string Title { get; set; } = string.Empty;
        public IssueType Type { get; set; } = IssueType.UserStory;
        public IssuePriority Priority { get; set; } = IssuePriority.None;
        public IssueStatus Status { get; set; } 
        public string Description { get; set; } = string.Empty;
        public Models.User SubmittedBy { get; set; }
        public Models.User? AssignedTo { get; set; }
        public int CurrentLaneId { get; set; }
    }
}
