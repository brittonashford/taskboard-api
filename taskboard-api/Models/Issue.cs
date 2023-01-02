using taskboard_api.DTOs.User;

namespace taskboard_api.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Title { get; set; } = string.Empty;
        public IssueType Type { get; set; } = IssueType.UserStory;
        public IssuePriority Priority { get; set; } = IssuePriority.None;
        public int? CurrentLaneId { get; set; } = null;
        public int IssueStatusId { get; set; } = 1;   
        public string Description { get; set; } = string.Empty;
        public int SubmittedById { get; set; }
        public int? AssignedToId { get; set; } = null;
        public int LastUpdatedById { get; set; }
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
