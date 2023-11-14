using Oefening_7_2_BlogEF.Entities;
using Oefening_7_2_BlogEF.ViewModels;

namespace Oefening_7_2_BlogEF.Services
{
    public interface IPostRepository
    {
        int AddPost(Post post);
        IEnumerable<Entities.Category> GetCategories();
        PostCategory GetPost(int postId);
        List<PostCategory> GetPosts(int categoryId);
        void UpdatePost(Post post);
    }
}