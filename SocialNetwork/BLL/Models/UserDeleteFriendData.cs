namespace SocialNetwork.BLL.Models;

public class UserDeleteFriendData
{
    public int UserId { get; set; }
    public int FriendId { get; set; }
    public string FriendEmail { get; set; }
}
