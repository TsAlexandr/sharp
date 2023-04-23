namespace sharp.Services.BlogsService
{
    public interface IBlogsService
    {
        Task<List<BlogsViewModel>> GetAllBlogs();
        Task<BlogsViewModel?> GetBlog(string id);
        Task<BlogsViewModel> CreateBlog(BlogInputModel blog);
        Task<BlogsViewModel?> UpdateBlog(string id, BlogInputModel blog);
        Task<BlogsViewModel?> DeleteBlog(string id);
    }
}
