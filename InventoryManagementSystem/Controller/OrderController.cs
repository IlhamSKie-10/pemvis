using InventoryManagementSystem.Models;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class OrderController
    {
        private readonly OrderModel model;

        public OrderController()
        {
            model = new OrderModel();
        }

        public List<OrderData> LoadOrders(string search)
        {
            return model.GetOrders(search);
        }

        public void DeleteOrder(string orderId, string productId, int quantity)
        {
            model.DeleteOrder(orderId);
            model.RestoreProductQuantity(productId, quantity);
        }
    }
}
