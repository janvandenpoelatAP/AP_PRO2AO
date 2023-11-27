using Microsoft.AspNetCore.Mvc;
using Oefening_08_01_BlogEF.Entities;
using Oefening_08_01_BlogEF.ViewModels;
using Oefening_08_01_BlogEF.Services;

namespace Oefening_08_01_BlogEF.Controllers;

[Route("api/[controller]")]
public class PostController : Controller
{
    private readonly IPostRepository postRepository;

    public PostController(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    [HttpGet]
    [Route("GetCategories")]
    public IActionResult GetCategories()
    {
        var categories = postRepository.GetCategories();
        if (categories == null)
        {
            return NotFound();
        }
        return Ok(categories);
    }
    [HttpGet]
    [Route("GetPosts")]
    public IActionResult GetPosts(int categoryId)
    {
        var posts = postRepository.GetPosts(categoryId);

        if (posts == null)
        {
            return NotFound();
        }
        return Ok(posts);
    }
    [HttpGet]
    [Route("GetPost")]
    public IActionResult GetPost(int postId)
    {
        var post = postRepository.GetPost(postId);

        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpPost]
    [Route("AddPost")]
    public IActionResult AddPost(PostCreateViewModel postCreateViewModel)
    {
        Post post = new Post()
        {
            Title = postCreateViewModel.Title,
            Description = postCreateViewModel.Description,
            CategoryId = postCreateViewModel.CategoryId,
            CreatedDate = postCreateViewModel.CreatedDate
        };
        postRepository.AddPost(post);
        return NoContent();
    }
    [HttpPut]
    [Route("UpdatePost")]
    public IActionResult UpdatePost(PostUpdateViewModel postUpdateViewModel)
    {
        Post post = new Post()
        {
            Title = postUpdateViewModel.Title,
            Description = postUpdateViewModel.Description,
            CategoryId = postUpdateViewModel.CategoryId,
            CreatedDate = postUpdateViewModel.CreatedDate
        };
        postRepository.UpdatePost(post);
        return NoContent();
    }
}
