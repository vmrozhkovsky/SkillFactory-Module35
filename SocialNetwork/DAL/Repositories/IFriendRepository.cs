using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

public interface IFriendRepository
{
    int Create(FriendEntity friendEntity);
    IEnumerable<FriendEntity> FindAllByUserId(int userId);
    IEnumerable<FriendEntity> FindByFriendId(int friendId);
    int Delete(int id);
}