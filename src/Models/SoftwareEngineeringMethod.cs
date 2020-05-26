using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public static class ArticleMethod
    {
        public const string Tdd = "TDD";
        public const string Bdd = "BDD";
        public const string PairProgramming = "Pair Programming";
        public const string PlanningPoker = "Planning Poker";
        public const string DailyStandupMeetings = "Daily Standup Meetings";
        public const string StoryBoards = "Story Boards";
        public const string UserStoryMapping = "User Story Mapping";
        public const string ContinuousIntegration = "Continuous Integration";
        public const string Retrospectives = "Retrospectives";
        public const string BurnDownChart = "Burn Down Chart";
        public const string RequirementsPrioritization = "Requirements Prioritization";
        public const string VersionControl = "Version Control";
        public const string CodeSharing = "Code Sharing";
    }

    public class SoftwareEngineeringMethod
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public int ArticleId { get; set; }

        public string Method { get; set; }
    }
}