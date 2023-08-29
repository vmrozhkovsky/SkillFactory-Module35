using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests;

public class Tests
{
    public static UserRepository userRepository;
    public static FriendRepository friendRepository;
    
    // Тест удаления пользователя с Id 1000 (предполагается, что не существует). Возвращаемое значение метода DeleteById не должно быть равно 1.
    [Test]
    public void UserDeleteByIdMustNotReturnOne()
    {
        userRepository = new UserRepository();
        Assert.AreNotEqual(1, userRepository.DeleteById(1000));
    }
    
    // Тест удаления друга с Id 1000 (предполагается, что не существует). Возвращаемое значение метода DeleteById не должно быть равно 1.
    [Test]
    public void FriendDeleteByIdMustNotReturnOne()
    {
        friendRepository = new FriendRepository();
        Assert.AreNotEqual(1, friendRepository.DeleteById(1000));
    }
}