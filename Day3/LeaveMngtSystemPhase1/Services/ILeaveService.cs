using System;
using System.Collections.Generic;

using LeaveMngtSystemPhase1.Models;

namespace LeaveMngtSystemPhase1.Services;

public interface ILeaveService { 
    void DisplayAll(List<LeaveRequest> leaveRequests);
    void ShowAllApprovals(List<IApprovable> approvables);
}
