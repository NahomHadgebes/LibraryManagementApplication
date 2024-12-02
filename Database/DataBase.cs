using LibraryManagementApplication.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementApplication.Database
{
    public class DataBase
    {
        [JsonPropertyName("Book")]
        public List<LibraryBook> BooksFromDataBase { get; set; }


        [JsonPropertyName("Arthur")]
        public List<Arthur> ArthursFromDataBase { get; set; }

    }
}
