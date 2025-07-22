using System;

namespace Day1Proj1Phase1.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        // Constructor
        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        // Method to Display User Info
        public void DisplayUser()
        {
            Console.WriteLine($"User Name: {Name}");
            Console.WriteLine($"User Role: {Role}");
        }
    }
}
