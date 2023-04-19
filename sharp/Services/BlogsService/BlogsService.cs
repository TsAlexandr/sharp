namespace sharp.Services.BlogsService
{
    public class BlogsService : IBlogsService
    {
        private static List<Blogs> blogs = new List<Blogs>
            {
                new Blogs
                {
                    Id = "qwerty",
                    Name = "Peter",
                    WebsiteUrl = "hello@gmail.com",
                    Description = "first blogs",
                    CreatedAt = DateTime.Now

                },
                new Blogs
                {
                    Id = "hello",
                    Name = "Glenn",
                    WebsiteUrl = "kudo@gmail.com",
                    Description = "second blogs",
                    CreatedAt = DateTime.Now
                }
            };
        Blogs IBlogsService.CreateBlog(Blogs blog)
        {
            blogs.Add(blog);
            return blog;
        }

        Blogs? IBlogsService.DeleteBlog(string id)
        {
            var blog = blogs.Find(x => x.Id == id);
            if (blog == null)
            {
                return null;
            }
            blogs.Remove(blog);
            return blog;
        }

        List<Blogs> IBlogsService.GetAllBlogs()
        {
            return blogs;
        }

        Blogs? IBlogsService.GetBlog(string id)
        {
            var blog = blogs.Find(x => x.Id == id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }

        Blogs? IBlogsService.UpdateBlog(string id, string name, string websiteUrl)
        {
            var blog = blogs.Find(x => x.Id == id);
            if (blog == null)
            {
                return null;
            }
            blog.Name = name;
            blog.WebsiteUrl = websiteUrl;
            return blog;
        }
    }
}
