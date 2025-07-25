using System;

using eCommerceApp.Models;

namespace eCommerceApp.Services
{
    public class ProductService : IProductService
    {
        public void DisplayAllProducts(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"- {product.Name} (Price: {product.Price}, Stock: {product.StockQuantity})");
            }
        }

        public void ViewAllOrderSummary(List<IPurchable> purchables)
        {
            if (purchables == null || purchables.Count == 0)
            {
                Console.WriteLine("No orders placed.");
                return;
            }
            Console.WriteLine("Order Summary:");
            foreach (var purchable in purchables)
            {
                purchable.OrderSummary();
            }
        }
    }
}
