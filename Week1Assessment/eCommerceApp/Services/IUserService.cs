using System;

using eCommerceApp.Models;

namespace eCommerceApp.Services
{
    public interface IUserService
    {
        void ViewAllUsers(List<User> users);
        void ViewAllCarts(List<IPurchable> purchables);
    }
}