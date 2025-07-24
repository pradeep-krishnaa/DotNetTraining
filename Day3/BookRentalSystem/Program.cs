using System;

using System.Collections.Generic;
using BookRentalSystem.Models;
using BookRentalSystem.Services;

public class Program
{
    public static void Main(string[] args)
    {
        Fiction book1 = new Fiction(1, "The Great Gatsby", "F. Scott Fitzgerald", true, "Classic");
        NonFiction book2 = new NonFiction(2, "Sapiens", "Yuval Noah Harari", true, "History");

        List<Book> books = new List<Book> { book1 , book2 };
        List<IRentable> rentables = new List<IRentable> { book1, book2 };

        BookService bookService = new BookService();

        bookService.ReportAllStatus(rentables);
        Console.WriteLine();
        book1.Rent();
        book2.Rent();
        Console.WriteLine();
        bookService.ReportAllStatus(rentables);
        Console.WriteLine();
        book1.Return();
        Console.WriteLine();
        bookService.ReportAllStatus(rentables);
        Console.WriteLine();

        bookService.DisplayAll(books);


    }
}

