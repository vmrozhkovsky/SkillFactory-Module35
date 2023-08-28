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
            int test = Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
            Console.WriteLine($"Test = {test}");
            return test;
        }
        public IEnumerable<FriendEntity> FindByFriendId(int friendId)
        {
            return Query<FriendEntity> (@"select * from friends where id = :id", new { user_id = friendId });
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }
    }
}
