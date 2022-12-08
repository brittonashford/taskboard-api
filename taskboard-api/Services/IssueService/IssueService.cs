using taskboard_api.Models;

namespace taskboard_api.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private static List<Issue> issues = new List<Issue>
        {
            new Issue
            {
                IssueId = 1,
                Title = "Test1"
            },
            new Issue
            {
                IssueId = 2,
                Title = "Test2"
            }
        };
        public List<Issue> AddIssue(Issue newIssue)
        {
            issues.Add(newIssue);
            return issues;
        }

        public List<Issue> GetAllIssues()
        {
            return issues;
        }

        public Issue GetIssueById(int id)
        {
            return issues.FirstOrDefault(i => i.IssueId == id);
        }
    }
}
