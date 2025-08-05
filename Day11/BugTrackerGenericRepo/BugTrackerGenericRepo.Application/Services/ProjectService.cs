using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;
using BugTrackerGenericRepo.Infrastructure.Repositories;


namespace BugTrackerGenericRepo.Application.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void CreateProject(Project project)
        {
            _projectRepository.Add(project);
        }
        public void UpdateProject(Project project)
        {
            _projectRepository.Update(project);
        }
        public void DeleteProject(int projectId)
        {
            _projectRepository.Delete(projectId);
        }
        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetById(projectId);
        }
        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }
    }
}
