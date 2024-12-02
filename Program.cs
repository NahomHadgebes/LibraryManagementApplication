using LibraryManagementApplication.Book;
using LibraryManagementApplication.Database;
using LibraryManagementApplication.Library;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string dataJSONfilPath = "LibraryData.json";

                DataBase updatedJSON = DatabaseHelper.LoadDataFromJson(dataJSONfilPath);

                List<LibraryBook> allBooks = updatedJSON.BooksFromDataBase;
                List<Arthur> allArthurs = updatedJSON.ArthursFromDataBase;

                LibraryMenu.ShowMenu(allBooks, allArthurs, dataJSONfilPath);
            }
        }

    }
}
