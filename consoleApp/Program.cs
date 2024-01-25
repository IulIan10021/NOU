using System;
using System.Collections.Generic;

public interface IPrintable
{
    void PrintDetails();
}

class Book : IPrintable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Titlu: {Title}, Autor: {Author}, ISBN: {ISBN}");
    }
}


class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        if (!books.Contains(book))
        {
            books.Add(book);
            Console.WriteLine($"Cartea '{book.Title}' a fost adăugată în bibliotecă.");
        }
        else
        {
            Console.WriteLine($"Cartea '{book.Title}' se află deja în bibliotecă.");
        }
    }

    public void RemoveBook(Book book)
    {
        if (books.Contains(book))
        {
            books.Remove(book);
            Console.WriteLine($"Cartea '{book.Title}' a fost eliminată din bibliotecă.");
        }
        else
        {
            Console.WriteLine($"Cartea '{book.Title}' nu a fost găsită în bibliotecă.");
        }
    }

    public void DisplayAllBooks()
    {
        if (books.Count > 0)
        {
            Console.WriteLine("Lista cărților din bibliotecă:");
            foreach (var book in books)
            {
                book.PrintDetails();
            }
        }
        else
        {
            Console.WriteLine("Biblioteca este goală.");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Library library = new Library();

            Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "978-0-316-76948-0");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "978-0-06-112008-4");

            library.AddBook(book1);
            library.AddBook(book2);

            library.DisplayAllBooks();

            library.RemoveBook(book1);

            library.DisplayAllBooks();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare: {ex.Message}");
        }
    }
}
