using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApplication.Book
{
    public class LibraryBook
    {
        public string Titel { get; set; }

        public string Arthur { get; set; }

        public string Genre { get; set; }

        public int PublishedYear { get; set; }

        public int ISBN { get; set; }

        public int Id { get; set; }


        public LibraryBook(string titel, string arthur, string genre, int publishedYear, int isbn, int id)
        {
            Titel = titel;
            Arthur = arthur;
            Genre = genre;
            PublishedYear = publishedYear;
            ISBN = isbn;
            Id = id;
        }
    }
}
