using System;

namespace eCommerceApp.Models
{
    public class Clothing : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public Clothing(int id, string name, decimal price, string description, int stockQuantity, string size, string color)
            : base(id, name, price, description, stockQuantity)
        {
            Size = size;
            Color = color;
        }
        public override void DisplayProdDetails()
        {
            Console.WriteLine($"Product ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Category: Clothing");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Stock Quantity: {StockQuantity}");
        }
    }
}