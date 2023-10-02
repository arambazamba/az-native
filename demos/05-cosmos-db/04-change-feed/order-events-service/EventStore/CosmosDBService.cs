﻿using Microsoft.Azure.Cosmos;

namespace FoodApp.Orders
{
    public class OrderEventsStore : IOrderEventsStore
    {
        private Container container;
        public OrderEventsStore(
                CosmosClient dbClient,
                string databaseName,
                string containerName)
        {
            container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(string queryString)
        {
            var query = container.GetItemQueryIterator<Order>(new QueryDefinition(queryString));
            List<Order> results = new List<Order>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }


        public async Task<Order> GetOrderAsync(string id, string customerId)
        {
            try
            {
                ItemResponse<Order> response = await container.ReadItemAsync<Order>(id, new PartitionKey(customerId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<string> CreateOrderEventAsync(OrderEvent item)
        {
            var od = await container.CreateItemAsync<OrderEvent>(item, new PartitionKey(item.Id));
            return od.Resource.Id;
        }

        public async Task CancelOrderAsync(Order item)
        {
            item.CanceledByUser = true;
            await container.UpsertItemAsync<Order>(item, new PartitionKey(item.Id));
        }
    }
}