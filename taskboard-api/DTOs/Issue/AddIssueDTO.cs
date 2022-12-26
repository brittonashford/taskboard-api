namespace taskboard_api.DTOs.Issue
{
    public class AddIssueDTO
    {
        public string Title { get; set; } = string.Empty;
        public IssueType Type { get; set; } = IssueType.UserStory;
        public IssuePriority Priority { get; set; } = IssuePriority.None;
        public int? AssignedToId { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
    }
}
