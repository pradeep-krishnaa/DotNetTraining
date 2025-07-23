using Day2Proj2.Models;
using System; 

namespace Day2Proj2;

public class Program {
    public static void Main(string[] args) {

        List<SupportTicket> tickets = new List<SupportTicket>();
        var bugReport = new Models.BugReport(1, "Login Bug", "Unable to login with valid credentials", "Alice", "Open", "High");
        var featureRequest = new Models.FeatureRequest(2, "New Login Feature", "Add social media login options", "Bob", "Open", "Charlie", "2023-12-31");
        tickets.Add(bugReport);
        tickets.Add(featureRequest);


        foreach(var ticket in tickets) {
            ticket.Display();
        }

        Console.WriteLine("----------------------------------------------------");

        foreach (var ticket in tickets.OfType<IReportable>()) {
            ticket.ReportStatus();
        }

        Console.WriteLine("----------------------------------------------------");

        bugReport.CloseTicket();
        featureRequest.CloseTicket();
        Console.WriteLine("----------------------------------------------------");

        Console.WriteLine("After closing tickets:");

        foreach (var ticket in tickets.OfType<IReportable>())
        {
            ticket.ReportStatus();
        }
        Console.WriteLine("----------------------------------------------------");


    }
}





