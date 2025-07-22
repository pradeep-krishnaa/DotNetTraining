using System;

namespace Day1Proj2.Models
{

	public class SupportAgent
	{
		public int AgentId { get; set; }
		public string Name { get; set; }
		public string Dept { get; set; }

		public SupportAgent(int aid , string name , string dept)
		{
			AgentId = aid;
			Name = name;
			Dept = dept;

		}

		public void DisplayAgent()
		{
			Console.WriteLine("$Agent ID : {AgentId} - Name : {Name} - Dept : {Dept}");
		}
	}

}

