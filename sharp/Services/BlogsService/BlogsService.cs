namespace sharp.Services.BlogsService
{
    public class BlogsService : IBlogsService
    {
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
