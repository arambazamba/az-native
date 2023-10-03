﻿namespace FoodApp.Orders
{
    public interface IOrdersRepository
    {        
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(string id, string customerId);
        Task<IEnumerable<Order>> GetOrdersByQueryAsync(string query);
        Task AddOrderAsync(Order Order);
        Task UpdateOrderAsync(string id, Order Order);
        Task DeleteOrderAsync(Order Order);
    }
}