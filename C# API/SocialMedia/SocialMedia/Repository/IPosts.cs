using SocialMedia.Models;

namespace SocialMedia.Repository
{
    public interface IPosts
    {
        Post GetPostById(int postId);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetPostsByUserId(int userId);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
