namespace taskboard_api.Models
{
    public class Lane
    {
        public int LaneId { get; set; }
        public string LaneName { get; set; }
        public List<Issue> IssuesInLane { get; set; }
    }
}
