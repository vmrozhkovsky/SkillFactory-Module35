using Microsoft.VisualStudio.TestPlatform.TestHost;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;

namespace SocialNetwork.Tests;

public class Tests
{
    public static UserRepository userRepository;
    public static FriendRepository friendRepository;
    
    [Test]
    public void UserDeleteByIdMustNotReturnOne()
    {
        userRepository = new UserRepository();
        Assert.AreNotEqual(1, userRepository.DeleteById(1000));
    }
    
    [Test]
    public void FriendDeleteByIdMustNotReturnOne()
    {
        friendRepository = new FriendRepository();
        Assert.AreNotEqual(1, friendRepository.DeleteById(1));
    }
}