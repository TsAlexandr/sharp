using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sharp.Services.BlogsService;

namespace sharp.Controllers
{
    [Route("blogs")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService _blogService;
        public BlogsController(IBlogsService blogService) { 
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blogs>>> GetAllBlogs()
        {
            return Ok(await _blogService.GetAllBlogs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blogs>> GetBlog(string id)
        {
            var blog = await _blogService.GetBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost()]
        public async Task<ActionResult<Blogs>> CreateBlog(Blogs blog)
        {
            var result = await _blogService.CreateBlog(blog);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Blogs>> UpdateBlog(string id, string name, string websiteUrl)
        {
            var blog =  await _blogService.UpdateBlog(id, name, websiteUrl);
            if(blog == null) 
            { 
                return NotFound(); 
            }
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Blogs>> DeleteBlog(string id)
        {
            var blog = await _blogService.DeleteBlog(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
    }
}
