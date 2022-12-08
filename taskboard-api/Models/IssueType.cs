using System.Text.Json.Serialization;

namespace taskboard_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueType
    {
        UserStory,
        Bug,
        Task
    }
}
