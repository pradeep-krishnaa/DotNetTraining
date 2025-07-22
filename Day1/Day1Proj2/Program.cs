using Day1Proj2.Models;

public class Program 
{
    public static void Main(string[] args)
    {
        SupportAgent agent1 = new SupportAgent(1, "Pradeep", "Technical Support");
        SupportAgent agent2 = new SupportAgent(2, "Krishnaa", "Customer Service");

        SupportRequest request1 = new SupportRequest(101, "Login Issue", "Open", agent1);
        SupportRequest request2 = new SupportRequest(102, "Payment Failure", "Open", agent2);

        Console.WriteLine("Before Resolving Request 1");
        request1.DisplayRequest();
        Console.WriteLine("---------------------------------------");
        request1.ResolveRequest();
        Console.WriteLine("After Resolving Request 1");
        request1.DisplayRequest();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Before Reassigning Request 2");
        request2.DisplayRequest();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Reassigning Request 2 to Agent 1");
        request2.ReassignRequest(agent1);
        Console.WriteLine("---------------------------------------");
        request2.DisplayRequest();


    }


}
