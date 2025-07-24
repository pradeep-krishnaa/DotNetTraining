using System;

using IssueTrackerPhase2SOLID.Models;

namespace IssueTrackerPhase2SOLID.Services;

public interface IIssueService
{
	
	void DisplayAllIssues(List<Issue> issues);
	void GetAllSummary(List<IReportable> issuesum);
	void GetAllReportStatus(List<IReportable> reportables);
}