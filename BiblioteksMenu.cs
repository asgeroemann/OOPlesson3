namespace Library
{
    internal class BiblioteksMenu
    {
        public static List<Book> Boghylde = [
            new Book("Bogen om C#", "Michell Cronberg", "9788799338238", 2021),
            new Book("Nightfall and other stories", "Isaac Asimov", "9780385081047", 1969),
            new Book("The C Programming Language", "Brian W. Kernighan, Dennis M. Ritchie", "9780131103627", 1988),
            new Book("På ski over Grønland", "Fridtjof Nansen", "9788702050010", 1890)
            ];

        public static Dictionary<string, Book> BogHyldeDict = Boghylde.ToDictionary(x => x.ISBN);
        public static List<Borrower> LånerRegister = [new Borrower("Asger"),
        new Borrower("Ellen")]; 

        public static void HovedMenu()
        {
            while (true) {
                Console.Clear();
                Console.WriteLine("Vælg et menu punkt");
                Console.WriteLine("1.\tVis alle bøger");
                Console.WriteLine("2.\tSøg efter en bog på titel");
                Console.WriteLine("3.\tLån en bog(ud fra ISBN)");
                Console.WriteLine("4.\tAflever en bog(ud fra ISBN)");
                Console.WriteLine("5.\tAfslut");
                Console.WriteLine();

                char tast;
                while ((tast = Console.ReadKey(true).KeyChar) <= '0' && tast >= '6')
                {
                    Console.Write($"\tFejl: {tast} ikke gyldigt input");
                }

                switch (tast) 
                {
                    case '1':
                        ListAlleBøger();
                        break;
                    case '2':
                        SøgTitelMenu();
                        break;
                    case '3':
                        LånISBNmenu();
                        break;
                    case '4':
                        AfleverISBNmenu();
                        break;
                    case '5':
                        return;
                    default: 
                        break;
                }


            }
        }

        private static void ListAlleBøger()
        {
            Console.Clear();
            Console.WriteLine($"Boghylden indeholder {Boghylde.Count} bøger:");
            foreach (var item in Boghylde)
            {
                Console.WriteLine(item.PrintInfo());
            }
            Console.ReadKey(true);
        }

        private static void SøgTitelMenu()
        {
            int resulttæller = 0;
            foreach (var item in Boghylde)
            {   
                Console.WriteLine("SØGNING PÅ BOGTITEL");
                Console.Write("Indtast søgeord: ");
                string? Søgeord = Console.ReadLine();
                if(String.IsNullOrEmpty(Søgeord))
                {
                    Console.WriteLine("Søgeordet kan ikke være tomt.");
                    Console.ReadKey(true);
                    return;
                }

                if (item.Title.Contains(Søgeord)) 
                {
                    Console.WriteLine(item.PrintInfo());
                    resulttæller++;
                }
                Console.WriteLine($"{resulttæller} resultater blev fundet.");

                Console.WriteLine("Tryk på Q for at afslutte.");
                while(Char.ToUpper(Console.ReadKey(true).KeyChar)!= 'Q'){}
                return;
            }
        }

        private static void LånISBNmenu()
        {
            Console.Clear();
            Console.WriteLine("LÅN EN BOG");
            Console.WriteLine();
            Console.WriteLine("Indtastlåner nr.");
            int lånerNr;
            while (!int.TryParse(Console.ReadLine(), out lånerNr))
            {
                Console.WriteLine("Ugyldigt input. Indtast et gyldigt lånernummer.");
            }
            var låner = LånerRegister.Find(l => l.BorrowerNumber == lånerNr); 
            if (låner == null)
            {
                Console.WriteLine($"Ingen låner fundet med nummer: {lånerNr}");
                Console.ReadKey(true);
                return;
            }
            Console.Write("Indtast ISBN: ");
            string? isbn = Console.ReadLine();
            var book = Boghylde.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine($"Ingen bog fundet med ISBN: {isbn}");
                Console.ReadKey(true);
                return;
            }
            try{
                book.CheckOut();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
                Console.ReadKey(true);
                return;
            }
            try
            {
                låner.BorrowBook();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
                book.Return(); //Læg bogen tilbage hvis låneren ikke kan låne flere bøger.
                Console.ReadKey(true);
                return;   
            }
            Console.WriteLine($"Bogen '{book.Title}' er nu udlånt.");
            Console.ReadKey(true);
        }

        private static void AfleverISBNmenu()
        {
            Console.Clear();
            Console.WriteLine("AFLEVER EN BOG");
            Console.WriteLine();
            Console.WriteLine("Indtast låner nr.");
            int lånerNr;
            while (!int.TryParse(Console.ReadLine(), out lånerNr))
            {
                Console.WriteLine("Ugyldigt input. Indtast et gyldigt lånernummer.");
            }
            var låner = LånerRegister.Find(l => l.BorrowerNumber == lånerNr); 
            if (låner == null)
            {
                Console.WriteLine($"Ingen låner fundet med nummer: {lånerNr}");
                Console.ReadKey(true);
                return;
            }
            Console.Write("Indtast ISBN: ");
            string? isbn = Console.ReadLine();
            var book = Boghylde.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine($"Ingen bog fundet med ISBN: {isbn}");
                Console.ReadKey(true);
                return;
            }
            try{
                book.Return();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
                Console.ReadKey(true);
                return;
            }
            try
            {
                låner.ReturnBook();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
                book.CheckOut(); //Tag bogen tilbage hvis låneren ikke har nogen bøger at aflevere.
                Console.ReadKey(true);
                return;   
            }
            Console.WriteLine($"Bogen '{book.Title}' er nu afleveret.");
            Console.ReadKey(true);
        }
    }
}
