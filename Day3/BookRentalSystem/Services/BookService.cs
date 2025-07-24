using System;

using BookRentalSystem.Models;

namespace BookRentalSystem.Services;

public class BookService : IBookService
{
    public void ReportAllStatus(List<IRentable> rentables)
    {
  
        foreach (var rentable in rentables)
        {
            rentable.ReportStatus();
        }
    }

    public void DisplayAll(List<Book> books)
    {
        foreach (var book in books)
        {
            book.Display();
        }
    }
}