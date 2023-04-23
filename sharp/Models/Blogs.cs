namespace sharp.Models
{
    public class BlogsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlogsViewModel(string name, string websiteUrl, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            WebsiteUrl = websiteUrl;
            Description = description;
            CreatedAt = DateTime.Now.ToUniversalTime();
        }
    }
}
