using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public enum SoftwareEngineeringTechnique
    {
        Tdd,
        Bdd,
        PairProgramming,
        PlanningPoker,
        DailyStandupMeetings,
        StoryBoards,
        UserStoryMapping,
        ContinuousIntegration,
        Retrospectives,
        BurnDownChart,
        RequirementsPrioritization,
        VersionControl,
        CodeSharing
    }

    public class SoftwareEngineeringMethod
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public int ArticleId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SoftwareEngineeringTechnique Method { get; set; }
    }
}