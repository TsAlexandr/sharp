namespace sharp.Services.PostsService
{
    public class PostsService : IPostsService
    {
        private readonly DataContext _context;

        public PostsService(DataContext context)
        {
            _context = context;
        }

        async Task<PostsEntity?> IPostsService.CreatePost(PostInputModel post)
        {
            BlogsEntity? blog = await _context.Blogs.FindAsync(post.BlogId);
            Console.WriteLine(blog);
            if(blog is null)
            {
                return null;
            }
                 
            PostsEntity created = new(
                title: post.Title,
                shortDescription: post.ShortDescription,
                content: post.Content,
                blogId: blog.Id,
                blogName: blog.Name);
            _context.Posts.Add(created);
            await _context.SaveChangesAsync();
            return created;
        }

        async Task<PostsEntity?> IPostsService.DeletePost(string id)
        {
            PostsEntity? post = await _context.Posts.FindAsync(id);
            if (post == null) { return null; }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        async Task<List<PostsEntity>> IPostsService.GetAllPosts()
        {
            List<PostsEntity> posts = await _context.Posts.ToListAsync();
            return posts;
        }

        async Task<PostsEntity?> IPostsService.GetPost(string id)
        {
            PostsEntity? post = await _context.Posts.FindAsync(id);
            if(post == null) { return null; } 
            return post;
        }

        async Task<PostsEntity?> IPostsService.UpdatePost(string id, PostInputModel post)
        {
            PostsEntity? result = await _context.Posts.FindAsync(id);
            if (result == null) { return null; };
            result.Title = post.Title;
            result.ShortDescription = post.ShortDescription;
            result.Content = post.Content;

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
