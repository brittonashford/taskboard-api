using System.Text.Json.Serialization;

namespace taskboard_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueStatus
    {
        NotStarted,
        Development,
        Testing,
        FailedTesting,
        ReadyToDeploy,
        Complete
    }
}
