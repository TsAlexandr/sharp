namespace sharp.Services.PostsService
{
    public interface IPostsService
    {
        Task<List<PostsViewModel>> GetAllPosts();
        Task<PostsViewModel?> GetPost(string id);
        Task<PostsViewModel?> CreatePost(PostInputModel post);
        Task<PostsViewModel?> UpdatePost(string id, PostInputModel post);
        Task<PostsViewModel?> DeletePost(string id);
    }
}
