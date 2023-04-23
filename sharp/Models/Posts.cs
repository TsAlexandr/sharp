namespace sharp.Models
{
    public class PostsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string BlogId { get; set; }
        public string BlogName { get; set; }
        public DateTime CreatedAt { get; set; }

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
