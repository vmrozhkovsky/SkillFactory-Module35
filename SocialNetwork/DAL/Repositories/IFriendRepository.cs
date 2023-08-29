using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

public interface IFriendRepository
{
    int Create(FriendEntity friendEntity);
    IEnumerable<FriendEntity> FindAllByUserId(int userId);
    FriendEntity FindById(int friendId, int userId);
    int DeleteById(int id);
}