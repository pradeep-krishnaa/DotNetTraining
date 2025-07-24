using System;

namespace BookRentalSystem.Models;

public class NonFiction : Book, IRentable
{
    public string Category { get; set; }

    public NonFiction(int id, string title, string author, bool isAvailable, string category) : base(id, title, author)
    {
        Category = category;
    }

    public void Rent()
    {
        IsAvailable = false;
        Console.WriteLine($"Non Fiction Book: #ID {Id} has been rented.");

    }

    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"Non Fiction Book: #ID {Id} has been returned.");
    }

    public void ReportStatus()
    {
        Console.WriteLine($"Non Fiction Book: #ID {Id} is {(IsAvailable ? "available" : "not available")} for rent.");
    }

    public override void Display()
    {
        Console.WriteLine($"Non Fiction Book: #ID {Id}, Title: {Title}, Author: {Author}, Category: {Category}, Available: {IsAvailable}");
    }
}