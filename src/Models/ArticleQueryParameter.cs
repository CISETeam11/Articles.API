using System.ComponentModel.DataAnnotations;

namespace Articles.API.Models
{
    public class ArticleQueryParameter
    {
        [StringLength(255, MinimumLength = 2)]
        public string Bibliography { get; set; }

        public string Method { get; set; }
    }
}