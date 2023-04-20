namespace sharp.Services.BlogsService
{
    public class BlogsService : IBlogsService
    {
        private static List<Blogs> blogs = new List<Blogs>
            {
                new Blogs
                {
                    Id = "qwerty",
                    Name = "Peter",
                    WebsiteUrl = "hello@gmail.com",
                    Description = "first blogs",
                    CreatedAt = DateTime.Now

                },
                new Blogs
                {
                    Id = "hello",
                    Name = "Glenn",
                    WebsiteUrl = "kudo@gmail.com",
                    Description = "second blogs",
                    CreatedAt = DateTime.Now
                }
            };
        private readonly DataContext _context;

        public BlogsService(DataContext context)
        {
            _context = context;
        }
        async Task<Blogs> IBlogsService.CreateBlog(Blogs blog)
        {
            _context.BlogsPlatform.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        async Task<Blogs?> IBlogsService.DeleteBlog(string id)
        {
            var blog = await _context.BlogsPlatform.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            _context.BlogsPlatform.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        async Task<List<Blogs>> IBlogsService.GetAllBlogs()
        {
            var blogs = await _context.BlogsPlatform.ToListAsync();
            return blogs;
        }

        async Task<Blogs?> IBlogsService.GetBlog(string id)
        {
            var blog = await _context.BlogsPlatform.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }

        async Task<Blogs?> IBlogsService.UpdateBlog(string id, string name, string websiteUrl)
        {
            var blog = await _context.BlogsPlatform.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            blog.Name = name;
            blog.WebsiteUrl = websiteUrl;

            await _context.SaveChangesAsync();

            return blog;
        }
    }
}
