using System.ComponentModel.DataAnnotations;

namespace sharp.Models
{
    public class BlogsEntity
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

        public List<PostsEntity> Posts { get; set; } = new List<PostsEntity>();

        public BlogsEntity(string name, string websiteUrl, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            WebsiteUrl = websiteUrl;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
