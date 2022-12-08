namespace taskboard_api.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Title { get; set; } = string.Empty;
        public IssueType Type { get; set; } = IssueType.UserStory;
        public IssuePriority Priority { get; set; } = IssuePriority.None;
        public IssueStatus Status { get; set; } = IssueStatus.NotStarted;
        //public Sprint? SprintAssignment { get; set; }
        //public Developer? DeveloperAssignment { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
