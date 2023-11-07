namespace EF;
public class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            // var user1 = new User { Name = "Voron2", Role = "Admin", Email = "voron@admin.ru"};
            // var user2 = new User { Name = "Galina2", Role = "User", Email = "galina@klim.ru"};
            //
            // db.Users.Add(user1);
            // db.Users.Add(user2);
            //db.SaveChanges();
            
            var book1 = new Book {Name = "3 Мушкетера", Year = "1892"};
            var book2 = new Book {Name = "Страх и ненависть", Year = "1892"};
            db.Book.AddRange(book1, book2);
            db.SaveChanges();
        }
    }
}