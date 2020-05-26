using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public enum ArticleMethodology
    {
        Scrum,
        Waterfall,
        Spiral,
        Xp,
        RationalUnifiedProcess,
        Crystal,
        CleanRoom,
        FeatureDrivenDevelopment,
        ModelDrivenDevelopment,
        DomainDrivenDevelopment,
        FormalMethods,
        ProblemDrivenDevelopment,
        CloudComputing,
        ServiceOrientedDevelopment,
        AspectOrientedDevelopment,
        ValuesDrivenDevelopment,
        ProductDrivenDevelopment,
        Agile
    }

    public class SoftwareEngineeringMethodology
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public int ArticleId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ArticleMethodology Methodology { get; set; }
    }
}
