namespace EF;

public class UserRepository
{
    private AppContext db;

    public UserRepository(AppContext db)
    {
        this.db = db;
    }

    public void AddUser(string name, string role, string email)
    {
        try
        {
            var user = new User { Name = name, Role = role, Email = email };
            db.Users.Add(user);
            // db.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public void DeleteUserById(int userId)
    {
        try
        {
            db.Users.Remove(db.Users.FirstOrDefault(user => user.Id == userId));
            // db.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public void UpdateUserById(int userId, string? name = null, string? role = null, string? email = null)
    {
        try
        {
            var user = db.Users.FirstOrDefault(user => user.Id == userId);
            if (name != null)
                user.Name = name;
            if (role != null)
                user.Role = role;
            if (email != null)
                user.Email = email;
            // db.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // throw;
        }
    }

    public List<User> ShowUserById(int userId = 0)
    {
        if (userId == 0)
        {
            var allUsers = db.Users.ToList();
            return allUsers;
        }
        else
        {
            var userById = db.Users.Where(user => user.Id == userId).ToList();
            return userById;
        }
    }
}