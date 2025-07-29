using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;   //add project ref -> Core


namespace LMS.Infrastructure.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        public readonly List<Leave> _leaves = new List<Leave>();
        public static int _nextId = 1;

        public List<Leave> GetAllLeaves()
        {
            return _leaves;
        }
        public Leave GetLeaveById(int id)
        {
            return _leaves.FirstOrDefault(l => l.Id == id);
        }
        public void AddLeave(Leave leave)
        {
            leave.Id = _nextId++;
            _leaves.Add(leave);
        }

        public void UpdateLeave(Leave leave)
        {
            var index = _leaves.FindIndex(l => l.Id == leave.Id);
            if (index != -1)
            {
                _leaves[index] = leave;
            }
        }

        public void DeleteLeave(int id)
        {
            var leave = _leaves.FirstOrDefault(l => l.Id == id);
            if (leave != null)
            {
                _leaves.Remove(leave);
            }
        }


    }
}
