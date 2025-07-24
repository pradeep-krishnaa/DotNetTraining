using System;

using BookRentalSystem.Models;

namespace BookRentalSystem.Services;

public interface IBookService 
{
    void ReportAllStatus(List<IRentable> rentables);
    void DisplayAll(List<Book> books);
}