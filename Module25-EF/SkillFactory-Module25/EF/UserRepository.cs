namespace EF;

public class UserRepository
{
    private AppContext db;

    public UserRepository(AppContext db)
    {
        this.db = db;
    }

    // Метод для добавления пользователя в базу
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

    // Метод для удаления пользователя из базы
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

    // Метод для изменения параметров пользователя в базе
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

    // Метод возвращает список всех пользователей в базе, если не указан userID
    // Если указан userID метод вернет список из одного пользователя.
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
    
    // Метод возвращает количество книг находящихся на руках у определенного пользователя. 
    public int CountBooksByUser(int userId)
    {
        var countBooksByUser = db.Books.Where(book => book.UserId == userId).Count();
        return countBooksByUser;
    }

    // Метод добавления определенной книги определенному пользователю 
    public void AddBookToUser(User user, Book book)
    {
        book.User = user;
    }
    
    // Метод возвращает true, если у определенного пользователя есть определенная книга
    public bool isBookByUser(User user, Book book)
    {
        try
        {
            if (book.UserId == user.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}