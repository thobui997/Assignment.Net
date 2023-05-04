interface ILoanable
{
    int LoanPeriod { get; }
    string Borrower { get; set; }
    void Borrow(string borrower);
    void Return();
}

interface IPrintable
{
    void Print();
}

public class Book : ILoanable, IPrintable
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int LoanPeriod { get { return 21; } }
    public string Borrower { get; set; }

    public void Borrow(string borrower)
    {
        if (Borrower == null)
        {
            Borrower = borrower;
            Console.WriteLine($"{Title} by {Author} has been borrowed by {Borrower}");
        }
        else
        {
            Console.WriteLine($"{Title} by {Author} is already borrowed by {Borrower}");
        }
    }

    public void Print()
    {
        Console.WriteLine($"Book: {Title} by {Author} (ISBN: {ISBN})");
    }

    public void Return()
    {
        if (Borrower != null)
        {
            Console.WriteLine($"{Title} by {Author} has been returned");
            Borrower = null;
        }
        else
        {
            Console.WriteLine($"{Title} by {Author} is not borrowed");
        }
    }
}

public class DVD : ILoanable, IPrintable
{
    public string Director { get; set; }
    public string Title { get; set; }
    public int LengthInMinutes { get; set; }
    public int LoanPeriod { get { return 7; } }
    public string Borrower { get; set; }

    public void Borrow(string borrower)
    {
        if (Borrower == null)
        {
            Borrower = borrower;
            Console.WriteLine($"{Title} directed by {Director} has been borrowed by {Borrower}");
        }
        else
        {
            Console.WriteLine($"{Title} directed by {Director} is already borrowed by {Borrower}");
        }
    }

    public void Return()
    {
        if (Borrower != null)
        {
            Console.WriteLine($"{Title} directed by {Director} has been returned");
            Borrower = null;
        }
        else
        {
            Console.WriteLine($"{Title} directed by {Director} is not borrowed");
        }
    }

    public void Print()
    {
        Console.WriteLine($"DVD: {Title} directed by {Director} ({LengthInMinutes} min)");
    }
}

public class CD : ILoanable, IPrintable
{
    public string Artist { get; set; }
    public string Album { get; set; }
    public int NumberOfTracks { get; set; }
    public int LoanPeriod { get { return 14; } }
    public string Borrower { get; set; }

    public void Borrow(string borrower)
    {
        Borrower = borrower;
        Console.WriteLine($"CD {Album} by {Artist} has been borrowed by {borrower}.");
    }

    public void Return()
    {
        Console.WriteLine($"CD {Album} by {Artist} has been returned.");
        Borrower = null;
    }

    public void Print()
    {
        Console.WriteLine($"CD: {Album} by {Artist} ({(Borrower == null ? "available" : "borrowed by " + Borrower)})");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // Create a CD object
        CD cd = new CD
        {
            Artist = "The Beatles",
            Album = "Abbey Road",
            Borrower = "John Smith"
        };

        // Print information about the CD
        cd.Print();

        // Create a DVD object
        DVD dvd = new DVD
        {
            Title = "The Shawshank Redemption",
            Director = "Frank Darabont",
            Borrower = "Jane Doe"
        };

        // Print information about the DVD
        dvd.Print();

        // Create a Book object
        Book book = new Book
        {
            Author = "J.K. Rowling",
            Title = "Harry Potter and the Philosopher's Stone",
            ISBN = "9780747532743",
            Borrower = "Bob Smith"
        };

        // Print information about the book
        book.Print();

        Console.ReadKey();
    }
}