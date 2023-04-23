using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sharp.Models
{
    public class BlogInputModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string WebsiteUrl { get; set; }

        public BlogInputModel(string name, string websiteUrl, string description) 
        {
            Name = name;
            WebsiteUrl = websiteUrl;
            Description = description;
        }
    }
}
