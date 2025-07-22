// See https://aka.ms/new-console-template for more information
using Day1Proj1Phase1.Models;

public class Program
{
    public static void Main(string[] args)
    {
        User user1 = new User(1, "Pradeep", "Admin");
        Ticket ticket1 = new Ticket(101, "Login Issue", "Unable to login with valid credentials", user1);

        user1.DisplayUser();
        Console.WriteLine("-----------------------------------");
        ticket1.DisplayTicket();
        Console.WriteLine("-----------------------------------");
        ticket1.CloseTicket();
        Console.WriteLine("Ticket after closing:");
        //Console.WriteLine("-----------------------------------");
        ticket1.DisplayTicket();

    }

}

//User user1 = new User(1, "Alice", "Admin");

//Ticket ticket1 = new Ticket(101, "Login Issue", "Unable to login with valid credentials", user1);

//user1.DisplayUser();
//Console.WriteLine("-----------------------------------");
//ticket1.DisplayTicket();
//Console.WriteLine("-----------------------------------");
//ticket1.CloseTicket();
//Console.WriteLine("Ticket after closing:");
//Console.WriteLine("-----------------------------------");
//ticket1.DisplayTicket();