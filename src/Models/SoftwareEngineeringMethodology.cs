﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.API.Models
{
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