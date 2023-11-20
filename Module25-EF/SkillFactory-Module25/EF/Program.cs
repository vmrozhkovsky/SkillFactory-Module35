namespace EF;
public class Program
{
    static void Main(string[] args)
    {
        
        using (var db = new AppContext())
        {
            var usersDb = new UserRepository(db);
            var booksDb = new BookRepository(db);
            
            // usersDb.AddUser("Vova", "Admin","");
            // usersDb.AddUser("User", "user","123@123.ru");
            // usersDb.AddUser("User2", "user","1234@1234.ru");
            // booksDb.AddBook("TestName2", 1990,"Драма", "Ленин");
            // booksDb.AddBook("TestName3", 2000,"Драма", "Сталин");
            // booksDb.AddBook("Книга", 2011,"Детектив", "Крупская");
            // booksDb.AddBook("Самая новая", 2023,"Комедия", "Петр 6");
            // var user = db.Users.FirstOrDefault(user => user.Id == 2);
            // var book = db.Books.FirstOrDefault(book => book.Id == 4);
            // booksDb.AddBookToUser(user, book);
            // usersDb.UpdateUserById(1, "Vladik", "Admin");
            // foreach (var user in usersDb.ShowUserById())
            // {
            //     Console.WriteLine(user.Name);
            // }
            // Console.WriteLine("По жанру:");
            // foreach (var book in booksDb.ShowBook("Драма"))
            // {
            //     Console.WriteLine(book.Name);
            // }
            // Console.WriteLine("По году:");
            // foreach (var book in booksDb.ShowBooks(true))
            // {
            //     Console.WriteLine(book.Name);
            // }
            // Console.WriteLine("По имени:");
            // foreach (var book in booksDb.ShowBooks("alphabet","asc"))
            // {
            //     Console.WriteLine(book.Name);
            // }
            // Console.WriteLine("По году:");
            // foreach (var book in booksDb.ShowBooks("year","asc"))
            // {
            //     Console.WriteLine(book.Name);
            // }
            // Console.WriteLine("Количество книг у пользователя:");
            // Console.WriteLine(booksDb.CountBooks(2));
            db.SaveChanges();

        }
    }
}