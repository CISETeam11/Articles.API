using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Journal { get; set; }

        public int Year { get; set; }

        public int? JournalIssue { get; set; }

        public int? Volume { get; set; }

        public string Pages { get; set; }

        public string Doi { get; set; }

        [JsonIgnore]
        public virtual ICollection<SoftwareEngineeringMethod> SoftwareEngineeringMethods { get; set; }

        [NotMapped]
        public virtual IEnumerable<string> Methods { get; set; }

        [JsonIgnore]
        public virtual ICollection<SoftwareEngineeringMethodology> SoftwareEngineeringMethodologies { get; set; }

        [NotMapped]
        public virtual IEnumerable<string> Methodologies { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<UserRating> UserRatings { get; set; }

        public double AverageRating { get; set; }

        public double NumberOfRatings { get; set; }
    }
}