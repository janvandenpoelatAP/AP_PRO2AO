using Microsoft.EntityFrameworkCore;
using Oefening_7_2_BlogEF.Entities;
using Oefening_7_2_BlogEF.ViewModels;

namespace Oefening_7_2_BlogEF.Services;

public class PostRepository : IPostRepository
{
    private BlogContext context;

    public PostRepository(BlogContext context)
    {
        this.context = context;
    }

    public IEnumerable<Entities.Category> GetCategories()
    {
        return context.Categories.ToList();
    }
    public List<PostCategory> GetPosts(int categoryId)
    {
        return context.Posts.Where(x => x.CategoryId == categoryId).Select(p =>
                new PostCategory
                {
                    PostId = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    CategoryName = p.Category.Name,
                    CreatedDate = p.CreatedDate
                }).ToList();
    }
    public PostCategory GetPost(int postId)
    {
        return context.Posts.Where(x => x.Id == postId).Select(p =>
        new PostCategory
        {
            PostId = p.Id,
            Title = p.Title,
            Description = p.Description,
            CategoryName = p.Category.Name,
            CreatedDate = p.CreatedDate
        }).FirstOrDefault();
    }
    public int AddPost(Post post)
    {
        context.Posts.Add(post);
        context.SaveChanges();
        return post.Id;
    }
    public void UpdatePost(Post post)
    {
        context.Posts.Update(post);
        context.SaveChanges();
    }
}
