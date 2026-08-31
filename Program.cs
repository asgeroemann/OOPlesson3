namespace Library;


public class Program
{
    public static void Main(string[] args)
    {
        //Opret bøger. 
        List<Book> Bøger = [];

        Bøger.Add(new Book("En fodrejse til Amager", "H. C. Andersen", 1829));
        Bøger.Add(new Book("Bogen om C#", "Michell Cronberg", "9788799338238", 2021));
        Bøger.Add(new Book("Bovrup-Kartoteket", "Ukendt"));

        //Opret lånere
        List<Borrower> Borrowers = [];
        Borrowers.Add(new Borrower("Asger"));
        Borrowers.Add(new Borrower("Ellen"));

        //Lån en bog
        Bøger[2].CheckOut();
        Borrowers[0].BorrowBook();

        //Prøv at låne samme bog igen; 
        try
        {
            Bøger[2].CheckOut();
        } catch (Exception ex) {
            Console.WriteLine($"{Bøger[2]} er allerede udlånt");
        }
    }
}
