using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Core.Entities;

namespace SupportDesk.Core.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        List<Ticket> GetTicketsWithUsers();
        List<Ticket> GetTicketsWithTags();     
        List<User> GetUsersWithTickets();
        List<(string TagName , int TicketCount)> GetTagTicketCount();
        List<(string TagName, int TicketCount)> GetTicketCountsByUsers();
        List<Ticket> GetTicketsByUserId(int userId);
        List<Ticket> GetTicketsByTagId(int tagId);
        List<object> GetTicketsWithUsersAndTags();

    }
}
