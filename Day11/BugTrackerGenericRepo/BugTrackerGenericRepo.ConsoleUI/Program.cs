using System;
using BugTrackerGenericRepo.Application.Services;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Infrastructure.Repositories;
using BugTrackerGenericRepo.Core.Interfaces;

namespace BugTrackerGenericRepo.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBugRepository bugRepository = new BugRepository();
            IProjectRepository projectRepository = new ProjectRepository();
            IUserRepository userRepository = new UserRepository();
            BugService bugService = new BugService(bugRepository);
            ProjectService projectService = new ProjectService(projectRepository);
            UserService userService = new UserService(userRepository);

            //Bugs with id , title , description, status, priority
            bugService.CreateBug(new Bug { BugId = 1, Title = "Bug 1", Description = "Description for Bug 1", Status = "Open", Priority = "High" });
            bugService.CreateBug(new Bug { BugId = 2, Title = "Bug 2", Description = "Description for Bug 2", Status = "In Progress", Priority = "Medium" });

            //Projects with id, name
            projectService.CreateProject(new Project { ProjectId = 1, ProjectName = "Project 1" });
            projectService.CreateProject(new Project { ProjectId = 2, ProjectName = "Project 2" });

            //Users with id, name
            userService.CreateUser(new User { UserId = 1, UserName = "User 1" });
            userService.CreateUser(new User { UserId = 2, UserName = "User 2" });

            // Display all bugs
            Console.WriteLine("Bugs:");
            foreach (var bug in bugService.GetAllBugs())
            {
                Console.WriteLine($"ID: {bug.BugId}, Title: {bug.Title}, Description: {bug.Description}, Status: {bug.Status}, Priority: {bug.Priority}");
            }
            Console.WriteLine();
            // Display all projects
            Console.WriteLine("Projects:");
            foreach (var project in projectService.GetAllProjects())
            {
                Console.WriteLine($"ID: {project.ProjectId}, Name: {project.ProjectName}");
            }
            Console.WriteLine();
            // Display all users
            Console.WriteLine("Users:");
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}");
            }
            Console.WriteLine();

            // Update a bug
            var bugToUpdate = bugService.GetBugById(1);
            if (bugToUpdate != null)
            {
                bugToUpdate.Title = "Updated Bug 1";
                bugToUpdate.Status = "Closed";
                bugService.UpdateBug(bugToUpdate);
                Console.WriteLine($"Updated Bug ID: {bugToUpdate.BugId}");
            }else
            {
                Console.WriteLine("Bug not found for update.");
            }
            //delete a bug
            var bugToDelete = bugService.GetBugById(2);
            if (bugToDelete != null)
            {
                bugService.DeleteBug(bugToDelete.BugId);
                Console.WriteLine($"Deleted Bug with ID: {bugToDelete.BugId}");
            }
            else
            {
                Console.WriteLine("Bug not found for deletion.");
            }


            //Update a user '
            var userToUpdate = userService.GetUserById(1);
            if (userToUpdate != null)
            {
                userToUpdate.UserName = "Updated User 1";
                userService.UpdateUser(userToUpdate);
                Console.WriteLine($"Updated User ID: {userToUpdate.UserId}");
            }
            else
            {
                Console.WriteLine("User not found for update.");
            }

            //Delete a user
            var userToDelete = userService.GetUserById(2);
            if (userToDelete != null)
            {
                userService.DeleteUser(userToDelete.UserId);
                Console.WriteLine($"Deleted User wth  User ID: {userToDelete.UserId}");
            }
            else
            {
                Console.WriteLine("User not found for deletion.");
            }

            // Update a project
            var projectToUpdate = projectService.GetProjectById(1);
            if (projectToUpdate != null)
            {
                projectToUpdate.ProjectName = "Updated Project 1";
                projectService.UpdateProject(projectToUpdate);
                Console.WriteLine($"Updated Project ID: {projectToUpdate.ProjectId}");
            }
            else
            {
                Console.WriteLine("Project not found for update.");
            }
            // Delete a project
            var projectToDelete = projectService.GetProjectById(2);
            if (projectToDelete != null)
            {
                projectService.DeleteProject(projectToDelete.ProjectId);
                Console.WriteLine($"Deleted Project with Project ID: {projectToDelete.ProjectId}");
            }
            else
            {
                Console.WriteLine("Project not found for deletion.");
            }

            // Display all bugs after update and deletion
            Console.WriteLine("\nBugs after updation and Deletion:");
            foreach (var bug in bugService.GetAllBugs())
            {
                Console.WriteLine($"ID: {bug.BugId}, Title: {bug.Title}, Description: {bug.Description}, Status: {bug.Status}, Priority: {bug.Priority}");
            }
            Console.WriteLine();
            // Display all projects after deletion
            Console.WriteLine("Projects after updation and deletion:");
            foreach (var project in projectService.GetAllProjects())
            {
                Console.WriteLine($"ID: {project.ProjectId}, Name: {project.ProjectName}");
            }
            Console.WriteLine();
            // Display all users after deletion
            Console.WriteLine("Users after updation and deletion:");
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");




        }
    }
}