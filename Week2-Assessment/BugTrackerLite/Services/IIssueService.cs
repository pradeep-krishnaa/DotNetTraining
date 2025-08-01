using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerLite.Models;
using BugTrackerLite.Data;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerLite.Services
{
    public interface IIssueService
    {
        int TicketCount { get; }
        int UserCount { get; }
        int TagCount { get; }
        int TicketTagCount { get; }

        Ticket GetTicketById(int ticketId);
        Tag GetTagById(int tagId);
        User GetUserById(int userId);

        List<Ticket> GetAllTicketsWithUsersandTags();

    }
}
