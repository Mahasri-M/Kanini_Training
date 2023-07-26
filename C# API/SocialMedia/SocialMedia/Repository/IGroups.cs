using System.Text.RegularExpressions;
namespace SocialMedia.Repository
{
    public interface IGroups
    {
        Group GetGroupById(int groupId);
        IEnumerable<Group> GetAllGroups();
        void CreateGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(Group group);
    }
}
