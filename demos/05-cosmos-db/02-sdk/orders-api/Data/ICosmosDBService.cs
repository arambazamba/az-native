﻿namespace FoodApp.Orders
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Order>> GetOrdersAsync(string query);
        Task<Order> GetOrderAsync(string id, string customerId);
        Task AddOrderAsync(Order Order);
        Task UpdateOrderAsync(string id, Order Order);
        Task DeleteOrderAsync(Order Order);
    }
}