using System;

using eCommerceApp.Models;

namespace eCommerceApp.Services
{
    public class  UserService : IUserService
    {
        public void ViewAllUsers(List<User> users)
        {
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No users available.");
                return;
            }
            Console.WriteLine("Registered Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"- {user.Name}");
            }
        }
        public void ViewAllCarts(List<IPurchable> purchables)
        {
            if (purchables == null || purchables.Count == 0)
            {
                Console.WriteLine("No carts available.");
                return;
            }
            Console.WriteLine("Cart Summary:");
            foreach (var purchable in purchables)
            {
                purchable.ViewCart();
            }
        }
    }
}