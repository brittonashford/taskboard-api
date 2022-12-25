using System.Text.Json.Serialization;

namespace taskboard_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueStatus
    {
        NotStarted,
        InformationNeeded,
        Development,
        Testing,
        FailedTesting,
        ReadyToDeploy,
        Complete
    }
}
