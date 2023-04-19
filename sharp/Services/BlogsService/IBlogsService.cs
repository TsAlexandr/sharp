namespace sharp.Services.BlogsService
{
    public interface IBlogsService
    {
        List<Blogs> GetAllBlogs();
        Blogs? GetBlog(string id);
        Blogs CreateBlog(Blogs blog);
        Blogs? UpdateBlog(string id, string name, string websiteUrl);
        Blogs? DeleteBlog(string id);
    }
}
