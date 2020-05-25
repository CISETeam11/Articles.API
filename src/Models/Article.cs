using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
    public class Article
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string? Journal { get; set; }

        public int Year { get; set; }

        public string Doi { get; set; }

        public int JournalIssue { get; set; }

        public int Volume { get; set; }

        public string Pages { get; set; }
    }
}