using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;

namespace BugTrackerGenericRepo.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new List<Project>();
        public void Add(Project entity)
        {
            _projects.Add(entity);
        }
        public void Update(Project entity)
        {
            var existingProject = GetById(entity.ProjectId);
            if (existingProject != null)
            {
                existingProject.ProjectId = entity.ProjectId;
                existingProject.ProjectName = entity.ProjectName;
            }
        }
        public void Delete(int id)
        {
            var project = GetById(id);
            if (project != null)
            {
                _projects.Remove(project);
            }
        }
        public Project GetById(int id)
        {
            return _projects.FirstOrDefault(p => p.ProjectId == id);
        }
        public List<Project> GetAll()
        {
            return _projects;

        }
    }
}
