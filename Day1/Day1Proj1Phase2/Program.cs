// See https://aka.ms/new-console-template for more information
//using Day1Proj1Phase1.Models;
using Day1Proj1Phase2.Models;

public class Program
{
    public static void Main(string[] args)
    {
        User user1 = new User(1, "Pradeep", "Developer");
        User user2 = new User(2, "Krishnaa", "QA");
        User user3 = new User(3, "Jeff", "Manager");
        Ticket ticket1 = new Ticket(1, "Login Issue", "Unable to login with valid credentials", user1, "High");
        Ticket ticket2 = new Ticket(2, "UI Bug", "Button not aligned properly", user2, "Medium");
        Ticket ticket3 = new Ticket(3, "Database Error", "Error connecting to the database", user3, "Critical");

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Before Reassigning Ticket 1");
        ticket1.DisplayTicket();
        Console.WriteLine("----------------------------------");
        ticket1.ReassignTicket(user2);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("After Reassigning Ticket 1");
        ticket1.DisplayTicket();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Displaying Ticket Summaries:");
        ticket1.DisplaySummary();
        Console.WriteLine("----------------------------------");
        ticket2.DisplaySummary();


    }

}

