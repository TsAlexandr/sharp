using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sharp.Services.PostsService;

namespace sharp.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostsViewModel>>> GetAllPosts()
        {
            return Ok(await _postsService.GetAllPosts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostsViewModel>> GetPost(string id)
        {
            var post = await _postsService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost()]
        public async Task<ActionResult<PostsViewModel>> CreatePost(PostInputModel post)
        {
            var result = await _postsService.CreatePost(post);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostsViewModel>> UpdatePost(string id, PostInputModel post)
        {
            var result = await _postsService.UpdatePost(id, post);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostsViewModel>> DeletePost(string id)
        {
            var post = await _postsService.DeletePost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
