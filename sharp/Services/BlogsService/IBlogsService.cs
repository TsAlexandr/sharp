namespace sharp.Services.BlogsService
{
    public interface IBlogsService
    {
        Task<List<Blogs>> GetAllBlogs();
        Task<Blogs?> GetBlog(string id);
        Task<Blogs> CreateBlog(Blogs blog);
        Task<Blogs?> UpdateBlog(string id, string name, string websiteUrl);
        Task<Blogs?> DeleteBlog(string id);
    }
}
