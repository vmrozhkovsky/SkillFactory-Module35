using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }

        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }
        public FriendEntity FindById(int friendId, int userId)
        {
            return QueryFirstOrDefault<FriendEntity>(@"select * from friends where friend_id = :friend_id and user_id = :user_id", new { friend_id = friendId, user_id = userId });
        }

        public int DeleteById(int id)
        {
            // return Execute(@"delete from friends where id = :id_p", new { id_p = id });
            return Execute($"delete from friends where id = :id_p", new { id_p = id });
        }
    }
}
