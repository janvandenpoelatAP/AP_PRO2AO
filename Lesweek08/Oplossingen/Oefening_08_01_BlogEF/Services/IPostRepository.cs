using Oefening_08_01_BlogEF.Entities;
using Oefening_08_01_BlogEF.ViewModels;

namespace Oefening_08_01_BlogEF.Services
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