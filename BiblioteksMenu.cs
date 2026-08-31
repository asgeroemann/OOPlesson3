

using System.Runtime.Intrinsics.X86;

namespace Library
{
    internal class BiblioteksMenu
    {
        public static List<Book> Boghylde = [];


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
                        break;
                    case '4':
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
            foreach (var item in Boghylde)
            {
                Console.WriteLine($"{item.Author}:",
                    $"{item.Title} ",
                    $"({item.PublicationYear}). ",
                    $"ISBN: {item.ISBN}",
                    $"{((item.IsOnLoan)?"UDLÅNT":"LEDIG")}");
            }
        }

        private static void SøgTitelMenu()
        {

        }

        private static void LånISBNmenu()
        {

        }

        private static void AfleverMenu()
        {

        }
    }
}
