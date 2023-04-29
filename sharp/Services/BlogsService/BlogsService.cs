namespace sharp.Services.BlogsService
{
    public class BlogsService : IBlogsService
    {
        private readonly DataContext _context;

        public BlogsService(DataContext context)
        {
            _context = context;
        }
        async Task<BlogsEntity> IBlogsService.CreateBlog(BlogInputModel blog)
        {
            BlogsEntity created = new(
                            blog.Name,
                            blog.WebsiteUrl,
                            blog.Description
                        );
            _context.Blogs.Add(created);
            await _context.SaveChangesAsync();
            return created;
        }

        async Task<BlogsEntity?> IBlogsService.DeleteBlog(string id)
        {
            BlogsEntity? blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        async Task<List<BlogsEntity>> IBlogsService.GetAllBlogs()
        {
            List<BlogsEntity> blogs = await _context.Blogs.ToListAsync();
            return blogs;
        }

        async Task<BlogsEntity?> IBlogsService.GetBlog(string id)
        {
            BlogsEntity? blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }

        async Task<BlogsEntity?> IBlogsService.UpdateBlog(string id, BlogInputModel blog)
        {
            BlogsEntity? result = await _context.Blogs.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            result.Name = blog.Name;
            result.WebsiteUrl = blog.WebsiteUrl;
            result.Description = blog.Description;

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
