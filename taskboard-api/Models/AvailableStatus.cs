namespace taskboard_api.Models
{
    public class AvailableStatus
    {
        public int AvailableStatusId { get; set; }
        public int LaneId { get; set; }
        public int IssueStatusId { get; set; }
        public int UserRoleId { get; set; }
    }
}
