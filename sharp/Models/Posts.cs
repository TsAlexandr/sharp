using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sharp.Models
{
    public class PostsViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("BlogId")]
        public string BlogId { get; set; }

        [Required]
        public string BlogName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public BlogsViewModel? Blogs { get; set; }

        public PostsViewModel(string title, string shortDescription, string content, string blogId, string blogName) 
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            ShortDescription = shortDescription; 
            Content = content;
            BlogId = blogId;
            BlogName = blogName;
            CreatedAt = DateTime.Now.ToUniversalTime();
        }
    }
}
