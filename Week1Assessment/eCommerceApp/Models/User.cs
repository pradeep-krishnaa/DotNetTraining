using System;

namespace eCommerceApp.Models
{
    public class User : IPurchable
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public List<Product> Cart { get; set; } = new List<Product>();

        public User(int uid, string name)
        {
            UserId = uid;
            Name = name;
            
        }
        public void DisplayUserDetails()
        {
            Console.WriteLine($"User ID: {UserId}");
            Console.WriteLine($"Name: {Name}");
        }
        

        public void Order(Product product , int quantity)
        {
            if(product.StockQuantity >= quantity)
            {
                product.StockQuantity -= quantity;
                Cart.Add(product);
                



                Console.WriteLine($"Order placed for {quantity} units of {product.Name}. Remaining stock: {product.StockQuantity}");
            }
            else
            {
                Console.WriteLine($"Insufficient stock for {product.Name}. Available stock: {product.StockQuantity}");
            }
            
        }
        

        public void CancelOrder(Product product ,int  quantity)
        {   
            

            product.StockQuantity += quantity;
            Cart.Remove(product);


            Console.WriteLine($"Order for {quantity} units of {product.Name} has been canceled. Updated stock: {product.StockQuantity}");
        }

        public void ViewCart()
        {
            Console.WriteLine($"Cart for User {Name}:");
            foreach (var product in Cart)
            {
                Console.WriteLine($"- {product.Name} ");
            }
        }

        public void OrderSummary()
        {
            Console.WriteLine($"Order Summary for User {Name}:");
            foreach (var product in Cart)
            {
                Console.WriteLine($"- {product.Name} (Price: {product.Price:C}, Quantity: {product.StockQuantity})");
            }
        }


    }
}