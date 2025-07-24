using System;

namespace BookRentalSystem.Models;

public abstract class Book
{
    //`Id`, `Title`, `Author`, `IsAvailable`
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    public abstract void Display();


}
