namespace Library_MS
{
    class Book
    {
        public Book(string title, string author, string iSBN, bool availability)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Availability = availability;
        }


        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }
        //public bool IsBorrowed { get; set; }
    }
    class Library
    {
        public List<Book> books = new List<Book>();
        public List<Book> AddBook(Book book)
        {
            books.Add(book);
            return books;
        }
        public bool SearchAboutBook(string title)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                if (title == books[i].Title)
                {
                    return true;
                }

            }
            return false;
        }
        public void BorrowBooks(string title)
        {
            foreach (Book b in books)
            {
                if (b.Title.Equals(title))
                {
                    if (b.Availability == false)
                    {
                        Console.WriteLine("Book Is taken");
                    }
                    else
                    {
                        Console.WriteLine(b.Author + ":" + b.Title);
                        b.Availability = false;
                    }
                }
            }
        }
        public bool BorrowBook(string title)
        {

            for (int i = 0; i < books.Count(); i++)
            {
                if (books[i].Title.Equals(title))
                {
                    //books[i].Title = "ahmed khaled tawfik";
                    books[i].Availability = false;
                    return true;
                }
            }
            return true;
        }
        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                if (books[i].Availability == false)
                {
                    Console.WriteLine("Book is borrowed");
                    books[i].Availability = true;

                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", true);
            Library library = new Library();
            library.AddBook(book);
            library.AddBook(new Book("1984", "George Orwell", "9780451524935", true));
            library.BorrowBook("1984");
            library.ReturnBook("1984");
            for (int i = 0; i < library.books.Count(); i++)
            {
                Console.WriteLine(library.books[i].Title);
                Console.WriteLine(library.books[i].Author);
                Console.WriteLine(library.books[i].ISBN);
                Console.WriteLine(library.books[i].Availability);
                Console.WriteLine("======================================");
            }
        }
    }
}