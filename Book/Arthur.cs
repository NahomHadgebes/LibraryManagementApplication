using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApplication.Book
{
    public class Arthur
    {
        public string Name { get; set; }

        public int Id { get; set; }
        public string Country { get; set; }

        public Arthur(string name, string country, int id)
        {
            Name = name;
            Id = id;
            Country = country;

        }
    }
}
