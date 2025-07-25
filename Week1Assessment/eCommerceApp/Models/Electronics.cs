using System;

namespace eCommerceApp.Models
{
	public class Electronics : Product
	{

		public string Brand { get; set; }
		public int WarrantyPeriod { get; set; } = 12; // Default warranty period in months
		public Electronics(int id, string name, decimal price, string description, int stockQuantity, int warrantyPeriod, string brand)
			: base(id, name, price, description, stockQuantity)
		{
			Brand = brand;
			WarrantyPeriod = warrantyPeriod;




		}
        public override void DisplayProdDetails()
        {
            Console.WriteLine($"Product ID: {Id}");
			Console.WriteLine($"Name: {Name}");
			Console.WriteLine($"Price: {Price:C}");
			Console.WriteLine($"Description: {Description}");
			Console.WriteLine($"Category: Electronics");
			Console.WriteLine($"Brand: {Brand}");
			Console.WriteLine($"Warranty Period: {WarrantyPeriod} months");
			Console.WriteLine($"Stock Quantity: {StockQuantity}");

		}
	}
}