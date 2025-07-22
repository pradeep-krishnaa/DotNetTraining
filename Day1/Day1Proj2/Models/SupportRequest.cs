using System;

namespace Day1Proj2.Models { 

	public class SupportRequest
	{
		public int RequestId { get; set; }
		public string Issue { get; set; }
		public string Status { get; set; }
		public DateTime CreatedOn { get; private set; } = DateTime.Now;
		public int ResolutionTime { get; set; } // in hours
		public bool IsResolved { get; set; } = false;
		public SupportAgent AssignedTo { get; set; }
		public SupportRequest(int requestId ,string issue , string status , SupportAgent assigneto)
		{
			RequestId = requestId;
			Issue = issue;
			Status = status;
			AssignedTo = assigneto;
		
		}

		public void ResolveRequest()
		{
			if (IsResolved)
			{
				return;
			}
			else
			{
				IsResolved = true;
				ResolutionTime = (int)(DateTime.Now - CreatedOn).TotalHours;
			}
		}

		public void ReassignRequest(SupportAgent newAgent)
		{
			AssignedTo = newAgent;
			Console.WriteLine($"Support request {RequestId} has been reassigned to {newAgent.Name}.");
		}

        public void DisplayRequest()
		{
				Console.WriteLine("Support Request Info");
				Console.WriteLine($"Request ID   : {RequestId}");
				Console.WriteLine($"Issue        : {Issue}");
				//Console.WriteLine($"Description  : {Description}");
				Console.WriteLine($"Status       : {Status}");
				Console.WriteLine($"Created On   : {CreatedOn}");
				Console.WriteLine($"Assigned To  : {AssignedTo.Name}");
				Console.WriteLine($"Resolved     : {IsResolved}");
				if (IsResolved)
				{
					Console.WriteLine($"Resolution Time: {ResolutionTime} hour(s)");
				}
        }
	}
}



