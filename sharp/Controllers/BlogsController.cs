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
        public async Task<ActionResult<List<BlogsViewModel>>> GetAllBlogs()
        {
            return Ok(await _blogService.GetAllBlogs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogsViewModel>> GetBlog(string id)
        {
            BlogsViewModel? blog = await _blogService.GetBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost()]
        public async Task<ActionResult<BlogsViewModel>> CreateBlog(BlogInputModel blog)
        {
            BlogsViewModel? result = await _blogService.CreateBlog(blog);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BlogsViewModel>> UpdateBlog(string id, BlogInputModel blog)
        {
            BlogsViewModel? result =  await _blogService.UpdateBlog(id, blog);
            if(result == null) 
            { 
                return NotFound(); 
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogsViewModel>> DeleteBlog(string id)
        {
            BlogsViewModel? blog = await _blogService.DeleteBlog(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
    }
}
