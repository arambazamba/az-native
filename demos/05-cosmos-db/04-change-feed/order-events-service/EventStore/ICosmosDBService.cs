﻿namespace FoodApp.Orders
{
    public interface IOrderEventsStore
    {
        Task<IEnumerable<Order>> GetOrdersAsync(string query);
        Task<Order> GetOrderAsync(string id, string customerId);
        Task<string> CreateOrderEventAsync(OrderEvent Event);
        Task CancelOrderAsync(Order Order);
    }
}