using System;

namespace IssueTrackerPhase2SOLID.Models;

public abstract class Issue
{
    // ID , Title , AssignedTo
    public int ID { get; set; }
    public string Title { get; set; }
    public string AssignedTo { get; set; }

    public bool IsValid { get; protected set; } = false;

    public Issue(int id, string title, string assignedTo)
    {
        ID = id;

        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(assignedTo))
        {
            Console.WriteLine("Invalid Issue: Title and AssignedTo cannot be empty.");
        }
        else if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid Issue: Title is required.");
        }
        else if (string.IsNullOrWhiteSpace(assignedTo))
        {
            Console.WriteLine("Invalid Issue: AssignedTo is required.");
        }
        else
        {
            Title = title;
            AssignedTo = assignedTo;
            IsValid = true;
        }
    }


    public abstract void Display();// if you want to have one display method and want to override it in derived classes, this display should be a virtual function
    

}

