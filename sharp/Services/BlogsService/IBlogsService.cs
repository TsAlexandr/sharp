namespace sharp.Services.BlogsService
{
    public interface IBlogsService
    {
        Task<List<BlogsEntity>> GetAllBlogs();
        Task<BlogsEntity?> GetBlog(string id);
        Task<BlogsEntity> CreateBlog(BlogInputModel blog);
        Task<BlogsEntity?> UpdateBlog(string id, BlogInputModel blog);
        Task<BlogsEntity?> DeleteBlog(string id);
    }
}
