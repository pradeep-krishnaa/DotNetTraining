using System;

public class SupportRequest
{
	public int RequestId { get; set; }
	public string Issue { get; set; }
	public string Status { get; set; }
    public DateTime CreatedOn { get; private set; } = DateTime.Now;
	public int ResolutionTime { get; set; } // in hours
	public Boolean IsResolved { get; set; } = false;
	public SupportAgent AssignedTo { get; set; };
    public SupportRequest(int requestId, string description, string status)
	{
		RequestId = requestId;
		Description = description;
		Status = status;
	}
	public void DisplayRequest()
	{
		Console.WriteLine($"Request ID: {RequestId} - Description: {Description} - Status: {Status}");
	}
}

