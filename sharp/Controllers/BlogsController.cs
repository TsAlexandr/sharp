using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            List<BlogsEntity> result = await _blogService.GetAllBlogs();
            return Ok(result.Adapt<List<BlogsViewModel>>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogsViewModel>> GetBlog(string id)
        {
            BlogsEntity? result = await _blogService.GetBlog(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<BlogsViewModel>());
        }

        [HttpPost()]
        public async Task<ActionResult<BlogsViewModel>> CreateBlog([FromBody] BlogInputModel blog)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BlogsEntity? result = await _blogService.CreateBlog(blog);
            return Ok(result.Adapt<BlogsViewModel>());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BlogsViewModel>> UpdateBlog(string id, BlogInputModel blog)
        {
            BlogsEntity? result =  await _blogService.UpdateBlog(id, blog);
            if(result == null) 
            { 
                return NotFound(); 
            }
            return Ok(result.Adapt<BlogsViewModel>());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogsViewModel>> DeleteBlog(string id)
        {
            BlogsEntity? blog = await _blogService.DeleteBlog(id);
            if (blog == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
