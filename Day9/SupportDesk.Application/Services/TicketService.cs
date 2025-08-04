using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Core.Entities;
using SupportDesk.Core.Interfaces;
using SupportDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SupportDesk.Application.Services
{
    public class TicketService : ITicketService


    {
        private readonly AppDBContext _context;
        public TicketService(AppDBContext context)
        {
            _context = context;
        }

        
        //body for implemented methods
        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }
        public List<Ticket> GetTicketsWithUsers()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Where(t => t.User != null)  //chumma 
                .ToList();
        }

        public List<Ticket> GetTicketsWithTags()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();
        }

             
        public List<User> GetUsersWithTickets()
        {
            return _context.Users
                .Include(u => u.Tickets)
                .ToList();
        }

        //public List<(string TagName, int TicketCount)> GetTagTicketCount()
        //{
        //    return _context.Tags
        //        .Select(tag => new 
        //        {
        //            TagName = tag.Name,
        //            TicketCount = tag.Tickets.Count
        //        })
        //        .AsEnumerable()
        //        .Select(x => (x.TagName, x.TicketCount))
        //        .ToList();

        //}

        public List<(string TagName, int TicketCount)> GetTagTicketCount()
        {
            return _context.Tags
                .Include(tag => tag.TicketTags)
                .Select(tag => new
                {
                    TagName = tag.Name,
                    TicketCount = tag.TicketTags.Count
                })
                .AsEnumerable()
                .Select(x => (x.TagName, x.TicketCount))
                .ToList();
        }


        public List<(string TagName, int TicketCount)> GetTicketCountsByUsers()
        {
            return _context.Users
                .Select(user => new 
                {
                    UserName = user.UserName,
                    TicketCount = user.Tickets.Count
                })
                .AsEnumerable()
                .Select(x => (x.UserName, x.TicketCount))
                .ToList();

        }
        public List<Ticket> GetTicketsByUserId(int userId)
        {
            return _context.Tickets
                .Where(t => t.UserId == userId)
                .ToList();

        }
        public List<Ticket> GetTicketsByTagId(int tagId)
        {
            return _context.Tickets
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .Where(t => t.TicketTags.Any(tt => tt.TagId == tagId))
                .ToList();
        }

        public List<object> GetTicketsWithUsersAndTags()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .Select(t => new
                {
                    TicketId = t.TicketId,
                    Title = t.Title,
                    UserName = t.User.UserName,
                    Tags = t.TicketTags.Select(tt => tt.Tag.Name).ToList()
                })
                .ToList<object>();
        }





    }
}
