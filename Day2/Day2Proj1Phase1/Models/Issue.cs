using System;

namespace Day2Proj1Phase1.Models;

public class Issue
{
	// ID , Title , AssignedTo
	public int ID { get; set; }
	public string Title { get; set; }
	public string AssignedTo { get; set; }

	public Issue(int id , string title , string assignedTo)
	{
	    ID = id;
		Title = title;
		AssignedTo = assignedTo;
    }

	public virtual void Display()    // if you want to have one display method and want to override it in derived classes, this display should be a virtual function
    {
			Console.WriteLine($" ID: {ID}, Title: {Title}, Assigned To: {AssignedTo}");
    }

}

