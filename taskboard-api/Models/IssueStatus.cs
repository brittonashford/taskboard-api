using System.Text.Json.Serialization;

namespace taskboard_api.Models
{
    public class IssueStatus
    {
        public int IssueStatusId { get; set; }
        public string IssueStatusName { get; set; }
    }
}
