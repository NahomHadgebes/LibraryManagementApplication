using LibraryManagementApplication.Book;
using LibraryManagementApplication.Database;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApplication.Library
{
    public class LibraryClass
    {
        public static void AddNewBook(List<LibraryBook> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            int newBookId = allBooks.Count == 0 ? 1 : allBooks.Max(b => b.Id) + 1;

            string title = InputHelper.GetNonEmptyString("Enter the title of the book:");

            string authorName = InputHelper.GetNonEmptyString("Enter the name of the author:");

            string genre = InputHelper.GetNonEmptyString("Enter the genre of the book:");

            int isbn = InputHelper.GetPositiveInt("Enter the ISBN of the book:");

            int year = InputHelper.GetPositiveInt("Enter the year the book was published:");

            LibraryBook newBook = new LibraryBook(title, authorName, genre, isbn, year, newBookId);
            
            allBooks.Add(newBook);

            DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

            Console.WriteLine($"Book '{title}' by {authorName} {year}, has now been added to your book library.");
            AnsiConsole.Markup($"[green]ID: {newBookId}[/]\n");
            AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]"); 
            Console.ReadKey();
        }


        public static void AddNewArthur(List<Arthur> allArthurs, List<LibraryBook> allBooks, string dataJSONfilPath)
        {
            int newarthurId = allBooks.Count == 0 ? 1 : allBooks.Max(b => b.Id) + 1;

            string authorName = InputHelper.GetNonEmptyString("Enter the name of the author you want to add:");

            string country = InputHelper.GetNonEmptyString("Name the country the arthur is from:");

            Arthur newArthur = new Arthur(authorName,newarthurId,country);
            allArthurs.Add(newArthur);

            DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

            Console.WriteLine($"{authorName} from {country} has now been added to you're Arthur library");
            AnsiConsole.Markup($"[green]ID: {newarthurId}[/]\n");
            AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
            Console.ReadKey();
        }

        public static void UppdateBokDetails(List<LibraryBook> allBooks, List<Arthur> allArthors, string dataJSONfilPath)
        {
            if (allBooks.Count == 0)
            {
                AnsiConsole.Markup("[red]There are no books available to update.[/]");
                return;
            }

            var bookChoices = allBooks.Select(b => b.Titel).ToList();

            var selectedBookTitle = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a book to update:")
                    .AddChoices(bookChoices)
            );

            var bookToUpdate = allBooks.FirstOrDefault(b => b.Titel == selectedBookTitle);
            if (bookToUpdate == null)
            {
                AnsiConsole.Markup("[red]Book not found.[/]");
                return;
            }

            Console.WriteLine($"Updating details for: {bookToUpdate.Titel}");

            var options = new string[] { "Title", "Author", "Genre", "ISBN", "Published Year" };

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Which field do you want to update?")
                    .AddChoices(options)
            );

            switch (selection)
            {
                case "Title":
                    bookToUpdate.Titel = InputHelper.GetNonEmptyString("Enter the new title:");
                    break;
                case "Author":
                    bookToUpdate.Arthur = InputHelper.GetNonEmptyString("Enter the new author:");
                    break;
                case "Genre":
                    bookToUpdate.Genre = InputHelper.GetNonEmptyString("Enter the new genre:");
                    break;
                case "ISBN":
                    bookToUpdate.ISBN = InputHelper.GetPositiveInt("Enter the new ISBN:");
                    break;
                case "Published Year":
                    bookToUpdate.PublishedYear = InputHelper.GetPositiveInt("Enter the new published year:");
                    break;
                default:
                    AnsiConsole.Markup("[red]Invalid choice.[/]");
                    return;
            }

            DatabaseHelper.SaveDataToJson(allBooks, allArthors, dataJSONfilPath);

            AnsiConsole.Markup($"[green]Book details have been updated.[/]\n");
            AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
            Console.ReadKey();
        }

        public static void UpdateArthurDetails(List<Arthur> allArthurs, List<LibraryBook> allBooks, string dataJSONfilPath)
        {
            if (allArthurs.Count == 0)
            {
                AnsiConsole.Markup("[red]There are no authors available to update.[/]");
                return;
            }

            var authorChoices = allArthurs.Select(a => a.Name).ToList();

            var selectedAuthorName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select an author to update:")
                    .AddChoices(authorChoices)
            );

            var authorToUpdate = allArthurs.FirstOrDefault(a => a.Name == selectedAuthorName);
            if (authorToUpdate == null)
            {
                AnsiConsole.Markup("[red]Author not found.[/]");
                return;
            }

            Console.WriteLine($"Updating details for: {authorToUpdate.Name}");

            var options = new string[] { "Name", "Country" };

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Which field do you want to update?")
                    .AddChoices(options)
            );

            switch (selection)
            {
                case "Name":
                    authorToUpdate.Name = InputHelper.GetNonEmptyString("Enter the new name:");
                    break;
                case "Country":
                    authorToUpdate.Country = InputHelper.GetNonEmptyString("Enter the new country:");
                    break;
                default:
                    AnsiConsole.Markup("[red]Invalid choice.[/]");
                    return;
            }

            DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

            AnsiConsole.Markup($"[green]Arthur have been updated.[/]\n");
            AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
            Console.ReadKey();
        }
        public static void RemoveAuthor(List<Arthur> allArthurs, List<LibraryBook> allBooks, string dataJSONfilPath)
        {
            if (allArthurs.Count == 0)
            {
                AnsiConsole.Markup("[red]There are no authors available to remove.[/]");
                return;
            }

            var authorChoices = allArthurs.Select(a => a.Name).ToList();

            var selectedAuthorName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select an author to remove:")
                    .AddChoices(authorChoices)
            );

            var authorToRemove = allArthurs.FirstOrDefault(a => a.Name == selectedAuthorName);
            if (authorToRemove == null)
            {
                AnsiConsole.Markup("[red]Author not found.[/]");
                return;
            }

            bool confirmation = AnsiConsole.Prompt(
                new ConfirmationPrompt($"Are you sure you want to remove '{authorToRemove.Name}'?")
            );

            if (confirmation)
            {
                allArthurs.Remove(authorToRemove);
                DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);
                AnsiConsole.Markup($"[red]Author '{authorToRemove.Name}' has been removed.[/]\n");
                AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.Markup($"[red]Operation canceled.[/]");
            }

        }
        public static void RemoveBook(List<LibraryBook> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            if (allBooks.Count == 0)
            {
                AnsiConsole.Markup("[red]There are no books available to remove.[/]");
                return;
            }

            var bookChoices = allBooks.Select(b => b.Titel).ToList();

            var selectedBookTitle = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a book to remove:")
                    .AddChoices(bookChoices)
            );

            var bookToRemove = allBooks.FirstOrDefault(b => b.Titel == selectedBookTitle);
            if (bookToRemove == null)
            {
                AnsiConsole.Markup("[red]Book not found.[/]");

                return;
            }

            bool confirmation = AnsiConsole.Prompt(
                new ConfirmationPrompt($"Are you sure you want to remove '{bookToRemove.Titel}'?")
            );

            if (confirmation)
            {
                allBooks.Remove(bookToRemove);
                DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);
                AnsiConsole.Markup($"Book '{bookToRemove.Titel}' has been removed.[/]\n");
                AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.Markup($"[red]Operation canceled.[/]"); 
            }
        }
        public static void ShowAllAuthors(List<Arthur> allArthurs)
        {
            if (allArthurs.Count == 0)
            {
                AnsiConsole.Markup($"[red]There are no authors available.[/]");
                return;
            }

            var authorChoices = allArthurs.Select(a => a.Name).ToList();

            var table = new Table();
            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[yellow]Name[/]");
            table.AddColumn("[yellow]Country[/]");

            foreach (var author in allArthurs)
            {
                table.AddRow(author.Id.ToString(), author.Name, author.Country);
            }

            AnsiConsole.Write(table);

            var selectedAuthorName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select an author to view more details:")
                    .AddChoices(authorChoices)
            );

            var authorToView = allArthurs.FirstOrDefault(a => a.Name == selectedAuthorName);
            if (authorToView != null)
            {
                Console.WriteLine($"Author Details:\nName: {authorToView.Name}\nCountry: {authorToView.Country}");
            }
            else
            {
                AnsiConsole.Markup($"[red]Author not found.[/]");
            }

            AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
            Console.ReadKey();
        }
        public static void ShowAllBooks(List<LibraryBook> allBooks)
        {
            Console.WriteLine("Your book collection:");

            if (allBooks.Count == 0)
            {
                AnsiConsole.Markup($"[red]No books available.[/]");
                return;
            }

            var bookChoices = allBooks.Select(b => b.Titel).ToList();

            var selectedBookTitle = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a book to view:")
                    .AddChoices(bookChoices)
            );

            var selectedBook = allBooks.FirstOrDefault(b => b.Titel == selectedBookTitle);
            if (selectedBook != null)
            {
                Console.WriteLine($"You selected: {selectedBook.Titel}");
                Console.WriteLine($"Author: {selectedBook.Arthur}");
                Console.WriteLine($"Genre: {selectedBook.Genre}");
                Console.WriteLine($"ISBN: {selectedBook.ISBN}");
                Console.WriteLine($"Published Year: {selectedBook.PublishedYear}");
            }
            else
            {
                AnsiConsole.Markup($"[red]Book not found.[/]");
            }

            AnsiConsole.Markup("[yellow]Press any key to return to the main menu...[/]");
            Console.ReadKey();
        }
        
    }
}
