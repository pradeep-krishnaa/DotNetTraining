using System;

namespace eCommerceApp.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        //public string Status { get; set; } = "Order Placed"; // Default status

        public Product(int id, string name, decimal price, string description,  int stockQuantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
         
            StockQuantity = stockQuantity;
        }
        


        public void UpdateStock(int quantity)
        {
            StockQuantity += quantity;
            Console.WriteLine($"Updating stock for {Name}. Current stock: {StockQuantity}");
        }

        public abstract void DisplayProdDetails();
    }
}