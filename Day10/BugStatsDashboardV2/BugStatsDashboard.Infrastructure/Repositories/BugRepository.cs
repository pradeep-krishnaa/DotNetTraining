using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;
using BugStatsDashboard.Core.Interfaces;


namespace BugStatsDashboard.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs;
        private readonly List<Project> _projects;
        private readonly List<User> _users;
        public BugRepository()
        {
            // Sample data for demonstration purposes
            
            //_projects = new List<Project>
            //{
            //    new Project { ProjectId = 1, ProjectName = "Project A" },
            //    new Project { ProjectId = 2, ProjectName = "Project B" }
            //};

            //_users = new List<User>
            //{
            //    new User { UserId = 1, UserName = "User 1" },
            //    new User { UserId = 2, UserName = "User 2" }
            //};

            var user1 = new User { UserId = 1, UserName = "User 1" };
            var user2 = new User { UserId = 2, UserName = "User 2" };
            _users = new List<User> { user1, user2 };

            var project1 = new Project { ProjectId = 1, ProjectName = "Project A" };
            var project2 = new Project { ProjectId = 2, ProjectName = "Project B" };
            _projects = new List<Project> { project1, project2 };


            _bugs = new List<Bug>
            {
                new Bug { BugId = 1, BugTitle = "Bug 1", Project = project1 , AssignedUser = user1, Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-2) },
                new Bug { BugId = 2, BugTitle = "Bug 2",  Project = project2 , AssignedUser = user1, Status = "In Progress", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-1) },
                new Bug { BugId = 3, BugTitle = "Bug 3",  Project = project1 , AssignedUser = user2, Status = "Closed", Priority = "Low", CreatedAt = DateTime.Now.AddDays(-2) },
                new Bug { BugId = 4, BugTitle = "Bug 4", Project = project2 , AssignedUser = user2, Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-3) },
                new Bug { BugId = 5, BugTitle = "Bug 5", Project = project1 , AssignedUser = user1, Status = "In Progress", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-2) }
            };
        }
        public List<Bug> GetAllBugs()
        {
            return _bugs;
        }
    }
}
