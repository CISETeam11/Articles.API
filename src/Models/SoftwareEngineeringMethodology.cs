using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public static class ArticleMethodology
    {
        public const string Agile = "Agile";
        public const string Scrum = "Scrum";
        public const string Waterfall = "Waterfall";
        public const string Spiral = "Spiral";
        public const string Xp = "XP";
        public const string RationalUnifiedProcess = "Rational Unified Process";
        public const string Crystal = "Crystal";
        public const string CleanRoom = "Clean Room";
        public const string FeatureDrivenDevelopment = "Feature Driven Development";
        public const string ModelDrivenDevelopment = "Model Driven Development";
        public const string DomainDrivenDevelopment = "Domain Driven Development";
        public const string FormalMethods = "Formal Methods";
        public const string ProblemDrivenDevelopment = "Problem Driven Development";
        public const string CloudComputing = "Cloud Computing";
        public const string ServiceOrientedDevelopment = "Service Oriented Development";
        public const string AspectOrientedDevelopment = "Aspect Oriented Development";
        public const string ValuesDrivenDevelopment = "Values Driven Development";
        public const string ProductDrivenDevelopment = "Product Driven Development";
    }

    public class SoftwareEngineeringMethodology
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public int ArticleId { get; set; }

        public string Methodology { get; set; }
    }
}
