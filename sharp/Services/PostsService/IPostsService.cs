namespace sharp.Services.PostsService
{
    public interface IPostsService
    {
        Task<List<PostsEntity>> GetAllPosts();
        Task<PostsEntity?> GetPost(string id);
        Task<PostsEntity?> CreatePost(PostInputModel post);
        Task<PostsEntity?> UpdatePost(string id, PostInputModel post);
        Task<PostsEntity?> DeletePost(string id);
    }
}
