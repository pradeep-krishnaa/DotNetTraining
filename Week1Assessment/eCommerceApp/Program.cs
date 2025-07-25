using System;

using eCommerceApp.Models;
using eCommerceApp.Services;

public class Program
{
    public static void Main(string[] args)
    {
        
        IProductService productService = new ProductService();
        IUserService userService = new UserService();


        
        User user1 = new User(1, "Pradeep");
        User user2 = new User(2, "Krishnaa");
        List<User> users = new List<User> { user1, user2 };



        Electronics product1 = new Electronics(1, "Smartphone", 699.99m, "Latest model with advanced features", 50, 24, "TechBrand");
        Clothing product2 = new Clothing(2, "T-Shirt", 19.99m, "Comfortable cotton t-shirt", 100, "M", "Blue");
        List<Product> products = new List<Product> { product1, product2 };
        
        
        
        user1.Order(product1, 2);
        user1.Order(product2, 1);
        user2.Order(product2, 3);
        user2.Order(product1, 5);
        user2.Order(product1, 100);

        product1.UpdateStock(45);

        user1.CancelOrder(product1, 2);

        user1.ViewCart();
        user2.ViewCart();



        productService.DisplayAllProducts(products);
        userService.ViewAllUsers(users);
    }
}