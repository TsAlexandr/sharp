using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            List<PostsEntity> result = await _postsService.GetAllPosts();
            return Ok(result.Adapt< List<PostsViewModel>>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostsViewModel>> GetPost(string id)
        {
            PostsEntity? result = await _postsService.GetPost(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<PostsViewModel>());
        }

        [HttpPost()]
        public async Task<ActionResult<PostsViewModel>> CreatePost(PostInputModel post)
        {
            PostsEntity? result = await _postsService.CreatePost(post);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<PostsViewModel>());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostsViewModel>> UpdatePost(string id, PostInputModel post)
        {
            PostsEntity? result = await _postsService.UpdatePost(id, post);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<PostsViewModel>());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostsViewModel>> DeletePost(string id)
        {
            PostsEntity? result = await _postsService.DeletePost(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<PostsViewModel>());
        }
    }
}
