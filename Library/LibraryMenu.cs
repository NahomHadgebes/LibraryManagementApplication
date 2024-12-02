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
    public class LibraryMenu
    {
        public static void ShowMenu(List<LibraryBook> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                AnsiConsole.Markup(
                "[bold cyan]WELCOME TO THE LIBRARY![/]\n" +
                "[italic bold yellow]\"The only thing you absolutely have to know is the location of the library.\"[/] - [bold yellow]Albert Einstein[/]\n"
            );

                AnsiConsole.Write(new FigletText("Open a book, open your world.")
                    .Centered()
                    .Color(Color.Magenta3));


                var table = new Table();
                table.AddColumn("[yellow]Option[/]");
                table.AddColumn("[yellow]Description[/]");

                table.AddRow("Add book", "Add a new book to the library");
                table.AddRow("Add author", "Add a new author to the library");
                table.AddRow("Update book details", "Update details of a book");
                table.AddRow("Update author details", "Update details of an author");
                table.AddRow("Remove book", "Remove a book from the library");
                table.AddRow("Remove author", "Remove an author from the library");
                table.AddRow("Show all books", "Show all books in the library");
                table.AddRow("Show all authors", "Show all authors in the library");
                table.AddRow("Exit", "Close the application");

                AnsiConsole.Write(table);

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Please select an option")
                        .AddChoices(
                            "Add book",
                            "Add author",
                            "Update book details",
                            "Update author details",
                            "Remove book",
                            "Remove author",
                            "Show all books",
                            "Show all authors",
                            "Exit"
                        )
                );

                switch (choice)
                {
                    case "Add book":
                        LibraryClass.AddNewBook(allBooks, allArthurs, dataJSONfilPath);
                        break;
                    case "Add author":
                        LibraryClass.AddNewArthur(allArthurs, allBooks, dataJSONfilPath);
                        break;
                    case "Update book details":
                        LibraryClass.UppdateBokDetails(allBooks, allArthurs, dataJSONfilPath);
                        break;
                    case "Update author details":
                        LibraryClass.UpdateArthurDetails(allArthurs, allBooks, dataJSONfilPath);
                        break;
                    case "Remove book":
                        LibraryClass.RemoveBook(allBooks, allArthurs, dataJSONfilPath);
                        break;
                    case "Remove author":
                        LibraryClass.RemoveAuthor(allArthurs, allBooks, dataJSONfilPath);
                        break;
                    case "Show all books":
                        LibraryClass.ShowAllBooks(allBooks);
                        break;
                    case "Show all authors":
                        LibraryClass.ShowAllAuthors(allArthurs);
                        break;
                    case "Exit":
                        running = false;
                        break;
                    default:
                        AnsiConsole.Markup("[bold red]Invalid choice, please try again.[/]");
                        break;
                }

                AnsiConsole.Markup("[bold green]Thank you for using the library! Goodbye![/]");
            }
        }
    }
}
