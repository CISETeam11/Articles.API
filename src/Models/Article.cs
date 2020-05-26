using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public class Article
    {
        [Key]
        [JsonIgnore]
        public int ArticleId { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Journal { get; set; }

        public int Year { get; set; }

        public int? JournalIssue { get; set; }

        public int? Volume { get; set; }

        public string Pages { get; set; }

        public string Doi { get; set; }

        public virtual IEnumerable<SoftwareEngineeringMethod> Methods { get; set; }
    }
}