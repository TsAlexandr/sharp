namespace sharp.Services.BlogsService
{
    public class BlogsService : IBlogsService
    {
        private readonly DataContext _context;

        public BlogsService(DataContext context)
        {
            _context = context;
        }
        async Task<BlogsViewModel> IBlogsService.CreateBlog(BlogInputModel blog)
        {
            BlogsViewModel created = new(
                            blog.Name,
                            blog.WebsiteUrl,
                            blog.Description
                        );
            _context.BlogsViewModel.Add(created);
            await _context.SaveChangesAsync();
            return created;
        }

        async Task<BlogsViewModel?> IBlogsService.DeleteBlog(string id)
        {
            BlogsViewModel? blog = await _context.BlogsViewModel.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            _context.BlogsViewModel.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        async Task<List<BlogsViewModel>> IBlogsService.GetAllBlogs()
        {
            List<BlogsViewModel> blogs = await _context.BlogsViewModel.ToListAsync();
            return blogs;
        }

        async Task<BlogsViewModel?> IBlogsService.GetBlog(string id)
        {
            BlogsViewModel? blog = await _context.BlogsViewModel.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }

        async Task<BlogsViewModel?> IBlogsService.UpdateBlog(string id, BlogInputModel blog)
        {
            BlogsViewModel? result = await _context.BlogsViewModel.FindAsync(id);
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
