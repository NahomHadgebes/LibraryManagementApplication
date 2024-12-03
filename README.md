Library Management System
A console-based library management application that allows users to manage books, authors, and library data interactively.
This project demonstrates principles of object-oriented programming (OOP), JSON file handling, and creating a visually appealing console interface using Spectre.Console.

Table of Contents
Features
Installation
Usage
Technologies Used
Code Structure
Future Improvements

Features
Explore the Library: Browse books and authors stored in the system.
Manage Books:
Add new books.
Update book details.
Remove books from the library.
Manage Authors:
Add new authors.
Update author details.
Remove authors from the library.
Persistent Data: Stores library data in a JSON file (LibraryData.json) for future sessions.
Interactive User Interface: Styled console menu and prompts using Spectre.Console.
Inspirational Quotes: Displays motivational library-related quotes to enhance the user experience.

Installation
Clone the repository:
git clone https://github.com/yourusername/library-management-system.git
cd library-management-system

Install dependencies:
dotnet add package Spectre.Console

Build and run:
dotnet build
dotnet run

Code Structure
Program.cs: Entry point of the application.
LibraryMenu.cs: Manages the main menu and user interaction.
LibraryClass.cs: Contains the business logic for managing books and authors.
DatabaseHelper.cs: Handles reading and writing data to/from LibraryData.json.
Models:
LibraryBook.cs: Represents a book in the library.
Arthur.cs: Represents an author in the library.
DataBase.cs: Represents the structure of the JSON database.

Technologies Used
C# and .NET 6: Core programming language and framework.
JSON: Data storage format for books and authors.
Spectre.Console: Library for creating a styled and interactive console user interface.

Future Improvements
Add search functionality.
Enable sorting and filtering of books.
Implement book borrowing features.

This Library Management System aims to simplify library data management while offering a visually appealing and interactive experience. Feel free to contribute or suggest new features!
