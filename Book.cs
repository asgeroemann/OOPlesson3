namespace Library
{

    public class Book
    {

        //FELTER
        private string _title;
        private string _author;
        private string _ISBN;
        private int _publicationYear;
        private bool _isOnLoan;

        //PROPERTIES
        public string Title
        {
            get { return _title; }
            private set { if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Titel må ikke være tom.", nameof(value));
                }
                _title = value;
            }
        }

        public string Author
        {
            get { return _author; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Forfatternavn må ikke være tom.", nameof(value));
                }
                _author = value;
            }
        }

        public int PublicationYear {
            get { return _publicationYear; }
            private set { _publicationYear = value; }
        }

        public string ISBN
        {
            get { return _ISBN; }
            private set { _ISBN = value; }
        }

        public bool IsOnLoan { 
            get { return _isOnLoan; }
            private set { _isOnLoan = value;}
        }

        //Konstruktører
        public Book(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
            IsOnLoan = false;
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            ISBN = "";
            PublicationYear = Int32.MinValue; //Brug minvalue som "ukendt årstal"
            IsOnLoan = false;
        }

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = "";
            PublicationYear = publicationYear;
            IsOnLoan = false;
        }

        //Metoder
        public void CheckOut()
        {
            if (_isOnLoan) throw new InvalidOperationException("Bogen er allerede udlånt.");
            else { _isOnLoan = true; }
        }

        public void Return()
        {
            if (!_isOnLoan) { throw new InvalidOperationException("Bogen er ikke udlånt."); }
            else {  _isOnLoan = false; }
        }
    }
}
