namespace Library
{
    internal class Borrower
    {
        //FELTER
        public string Name { get; set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Låner navn må ikke være tomt.", nameof(value));
                field = value;
            } 
        }
        public uint BorrowerNumber { get; private set; }
        public uint NumberOfBooksLoaned { get; private set; }

        private static uint burrowerNumbersTally = 0; //Static variabel til at holde styr på lånenummer rækken. 
        private const uint MaxLoans = 5; 


        //Konstruktører
        public Borrower(string name)
        {
            Name = name;
            BorrowerNumber = ++burrowerNumbersTally;
            NumberOfBooksLoaned = 0; 
        }


        //Metoder
        public void BorrowBook()
        {
            if (NumberOfBooksLoaned >= MaxLoans) throw new InvalidOperationException($"Maximum for udlån ({MaxLoans}). er nået.");
            else NumberOfBooksLoaned++;
        }

        public void ReturnBook()
        {
            if (NumberOfBooksLoaned == 0) throw new InvalidOperationException($"Ingen bøger er lånt.");
            else NumberOfBooksLoaned--;
        }
    }

}

