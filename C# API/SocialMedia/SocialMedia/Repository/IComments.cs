using SocialMedia.Models;

namespace SocialMedia.Repository
{
    public interface IComments
    {
        Comment GetCommentById(int commentId);
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        IEnumerable<Comment> GetCommentsByUserId(int userId);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
