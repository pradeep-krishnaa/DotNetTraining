using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using StudentCourseTracker.Models;

namespace StudentCourseTracker
{
    class program
    {
        static void Main(String[] args)
        {
            var context = new CourseContext();
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Courses', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, 0)");
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. View Students with Courses");
                Console.WriteLine("4. Update a STudent");
                Console.WriteLine("5. Delete a student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                
                var choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddCourse(context);
                        break;
                    case "2":
                        AddStudent(context);
                        break;
                    case "3":
                        ViewStudents(context);
                        break;
                    case "4":
                        UpdateStudent(context);
                        break;
                    case "5":
                        DeleteStudent(context);
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting the application.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        static void AddCourse(CourseContext context)
        {
            Console.Write("Enter Course Name: ");
            var courseName = Console.ReadLine();
            
            var course = new Course { CourseName = courseName };
            context.Courses.Add(course);
            context.SaveChanges();
            Console.WriteLine("Course added successfully.");
        }
        static void AddStudent(CourseContext context)
        {
            Console.Write("Enter Student Name: ");
            var studentName = Console.ReadLine();
            
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            var student = new Student { StudentName = studentName, CourseId = courseId };
            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student added successfully.");
        }
        static void ViewStudents(CourseContext context)
        {
            var students = context.Students
                .Include(s => s.Course)
                .ToList();
            Console.WriteLine("Students with Course Information:");
            foreach (var student in students)
            {
                string courseName = student.Course != null ? student.Course.CourseName : "N/A";
                Console.WriteLine($"StudentId: {student.StudentId}, StudentName: {student.StudentName}, Course: {courseName}");
            }
        }
        static void UpdateStudent(CourseContext context)
        {
            Console.Write("Enter Student ID to update: ");
            int studentId = int.Parse(Console.ReadLine());
            
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                Console.Write("Enter new Student Name: ");
                student.StudentName = Console.ReadLine();
                
                Console.Write("Enter new Course ID: ");
                student.CourseId = int.Parse(Console.ReadLine());
                
                context.SaveChanges();
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        static void DeleteStudent(CourseContext context)
        {
            Console.Write("Enter Student ID to delete: ");
            int studentId = int.Parse(Console.ReadLine());
            
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}