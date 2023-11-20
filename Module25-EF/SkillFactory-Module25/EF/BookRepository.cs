namespace EF;

public class BookRepository
{
    private AppContext db;

    public BookRepository(AppContext db)
    {
        this.db = db;
    }
    
    public void AddBook(string name, int year, string genre, string author)
    {
        try
        {
            var book = new Book { Name = name, Year = year, Genre = genre, Author = author};
            db.Books.Add(book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    public void DeleteBookById(int bookId)
    {
        try
        {
            db.Books.Remove(db.Books.FirstOrDefault(book => book.Id == bookId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    public List<Book> ShowBooks(int bookId = 0)
    {
        if (bookId == 0)
        {
            var allBooks = db.Books.ToList();
            return allBooks;
        }
        else
        {
            var bookById = db.Books.Where(book => book.Id == bookId).ToList();
            return bookById;
        }
    }
    
    public List<Book> ShowBooks(string genre)
    {
         var bookByGenre = db.Books.Where(book => book.Genre == genre).ToList();
         return bookByGenre;
    }

    public List<Book> ShowBooks(bool lastBook, int fromDate = 0, int toDate = 0)
    {
        if (lastBook)
        {
            var lastBookByDate = db.Books.Where(book => book.Year == db.Books.Max(book => book.Year)).ToList();
            return lastBookByDate;
        }
        else
        {
            var bookByDate = db.Books.Where(book => book.Year >= fromDate && book.Year < toDate).ToList();
            return bookByDate;
        }
    }

    public List<Book> ShowBooks(string sortAttribute, string sortDirection = "asc")
    {
        switch (sortAttribute)
        {
            case "alphabet":
                if (sortDirection == "asc")
                {
                    var bookByName = db.Books.OrderBy(book => book.Name).ToList();
                    return bookByName;
                }
                else
                {
                    var bookByName = db.Books.OrderByDescending(book => book.Name).ToList();
                    return bookByName;
                }
            case "year":
                if (sortDirection == "asc")
                {
                    var bookByName = db.Books.OrderBy(book => book.Year).ToList();
                    return bookByName;
                }
                else
                {
                    var bookByName = db.Books.OrderByDescending(book => book.Year).ToList();
                    return bookByName;
                }
            default:
                return null;
        }
    }

    public int CountBooks(string attribute, string attributeValue)
    {
        switch (attribute)
        {
            case "author":
                var countBooksByAuthor = db.Books.Where(book => book.Author == attributeValue).Count();
                return countBooksByAuthor;
            case "genre":
                var countBooksByGenre = db.Books.Where(book => book.Genre == attributeValue).Count();
                return countBooksByGenre;
            default:
                return 0;
        }
    }

    public int CountBooks(int userId)
    {
        var countBooksByUser = db.Books.Where(book => book.UserId == userId).Count();
        return countBooksByUser;
    }

    public void AddBookToUser(User user, Book book)
    {
        book.User = user;
    }

    public bool isBookByName(string name, string author)
    {
        var booksByName = db.Books.Where(book => book.Name == name && book.Author == author).ToList();
        if (booksByName.Count > 0)
            return true;
        return false;
    }

    public bool isBookByUser(Book book, User user)
    {
        if (book.UserId == user.Id)
            return true;
        return false;
    }
}