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
    public class IssueService : IIssueService
    {
        private readonly AppDBContext _context;
        public IssueService(AppDBContext context)
        {
            _context = context;
        }
        public int TicketCount => _context.Tickets.Count();
        public int UserCount => _context.Users.Count();
        public int TagCount => _context.Tags.Count();
        public int TicketTagCount => _context.TicketTags.Count();

        public Ticket GetTicketById(int ticketId)
        {
            return _context.Tickets.Find(ticketId);
        }
        public Tag GetTagById(int tagId)
        {
            return _context.Tags.Find(tagId);
        }
        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public List<Ticket> GetAllTicketsWithUsersandTags()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();
        }
    }
}
