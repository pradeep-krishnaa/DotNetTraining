using System;

namespace eCommerceApp.Models
{
    public interface IPurchable
    {

        void ViewCart();
        void Order(Product prod , int quantity);
        void CancelOrder(Product prod, int quantity);
        void OrderSummary();
    }
}