using System.ComponentModel.DataAnnotations;

namespace sharp.Models
{
    public class BlogsViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string WebsiteUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        public List<PostsViewModel> Posts { get; set; } = new List<PostsViewModel>();

        public BlogsViewModel(string name, string websiteUrl, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            WebsiteUrl = websiteUrl;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
