using System;

using eCommerceApp.Models;

namespace eCommerceApp.Services
{
    public interface IProductService
    {
        void DisplayAllProducts(List<Product> product );

        
        void ViewAllOrderSummary(List<IPurchable> purchables);

    }
}