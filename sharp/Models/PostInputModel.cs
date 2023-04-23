using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sharp.Models
{
    public class PostInputModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public string BlogId { get; set; }
        public PostInputModel(string title, string shortDescription, string content, string blogId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            BlogId = blogId;
        }
    }
}
