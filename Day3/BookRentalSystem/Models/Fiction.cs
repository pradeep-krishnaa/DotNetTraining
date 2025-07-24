using System;

namespace BookRentalSystem.Models;

public class Fiction : Book , IRentable
{
    public string Genre { get; set; }

    public Fiction(int id, string title, string author, bool isAvailable , string genre) : base(id , title , author)
    {
        Genre = genre;
    } 

    public void Rent()
    {
        IsAvailable = false;
        Console.WriteLine($"Fiction Book: #ID {Id} has been rented.");
    }

    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"Fiction Book: #ID {Id} has been returned.");
    }

    public void ReportStatus()
    {
        Console.WriteLine($"Fiction Book: #ID {Id} is {(IsAvailable ? "available" : "not available")} for rent.");
    }

    public override void Display()
    {
        Console.WriteLine($"Fiction Book: #ID {Id}, Title: {Title}, Author: {Author}, Genre: {Genre}, Available: {IsAvailable}");
    }
}
