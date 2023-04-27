namespace sharp.Services.PostsService
{
    public class PostsService : IPostsService
    {
        private readonly DataContext _context;

        public PostsService(DataContext context)
        {
            _context = context;
        }

        async Task<PostsViewModel?> IPostsService.CreatePost(PostInputModel post)
        {
            BlogsViewModel? blog = await _context.Blogs.FindAsync(post.BlogId);
            Console.WriteLine(blog);
            if(blog is null)
            {
                return null;
            }
                 
            PostsViewModel created = new(
                title: post.Title,
                shortDescription: post.ShortDescription,
                content: post.Content,
                blogId: blog.Id,
                blogName: blog.Name);
            _context.Posts.Add(created);
            await _context.SaveChangesAsync();
            return created;
        }

        async Task<PostsViewModel?> IPostsService.DeletePost(string id)
        {
            PostsViewModel? post = await _context.Posts.FindAsync(id);
            if (post == null) { return null; }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        async Task<List<PostsViewModel>> IPostsService.GetAllPosts()
        {
            List<PostsViewModel> posts = await _context.Posts.ToListAsync();
            return posts;
        }

        async Task<PostsViewModel?> IPostsService.GetPost(string id)
        {
            PostsViewModel? post = await _context.Posts.FindAsync(id);
            if(post == null) { return null; } 
            return post;
        }

        async Task<PostsViewModel?> IPostsService.UpdatePost(string id, PostInputModel post)
        {
            PostsViewModel? result = await _context.Posts.FindAsync(id);
            if (result == null) { return null; };
            result.Title = post.Title;
            result.ShortDescription = post.ShortDescription;
            result.Content = post.Content;

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
