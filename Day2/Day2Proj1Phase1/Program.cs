using Day2Proj1Phase1.Models;

public class  Program
{
    public static void Main(string[] args)
    {
        // Create a list of issues
        List<Issue> issues = new List<Issue>
        {
            new Bug(1, "Login Bug", "Pradeep", "High"),
            new Day2Proj1Phase1.Models.Task(2, "fixing login bug", "Krishnaa", 5),
            //new Bug(3, "UI Glitch", "Charlie", "Medium"),
            //new Day2Proj1Phase1.Models.Task(4, "Database Migration", "Alice", 10)
        };
        // Display all issues
        Console.WriteLine("\nDisplaying Issues:");
        foreach (var issue in issues)
        {
            issue.Display();
        }
        // Report status for each issue
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Reporting Status of Issues:");
        foreach (var issue in issues.OfType<IReportable>())
        {
            issue.ReportStatus();
        }
    }

}
