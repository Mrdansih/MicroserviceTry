using Application.Order.RepositoryInterfaces;
using Application.Order.ServiceInterfaces;
using Confluent.Kafka;
using Domain.Order.ApiResponses;
using Domain.Order.Contracts;
using Domain.Order.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Application.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOrderEventPublisher _eventPublisher;

        public OrderService(IOrderRepository orderRepository, IOrderEventPublisher eventPublisher, IHttpClientFactory httpClientFactory)
        {
            _orderRepository = orderRepository;
            _eventPublisher = eventPublisher;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CreateOrderResult?> CreateNewOrderAsync(OrderDto request)
        {

            var stockInfo = await CheckStockAsync(request.ProductId, request.Quantity);

            if (stockInfo == null)
                return new CreateOrderResult(false, "Unable to reach ProductService");

            if (!stockInfo.Available)
                return new CreateOrderResult(false, $"Not enough stock. Available: {stockInfo.CurrentStock}");

            var order = new OrderEntity();

            order.ProductId = request.ProductId;
            order.CustomerName = request.CustomerName;
            order.Quantity = request.Quantity;
            order.OrderDate = DateTime.Now;

            var createdOrder = await _orderRepository.AddNewOrderAsync(order);

            if (createdOrder != null)
                await OrderProduceAsync(createdOrder);

            return new CreateOrderResult(true, "Order created succesfully");
        }

        private async Task<StockCheckResponses?> CheckStockAsync(int productId, int quantity)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ProductService");
                var response = await client.GetAsync($"/api/product/{productId}/check?quantity={quantity}");

                if(!response.IsSuccessStatusCode) return null;

                return await response.Content.ReadFromJsonAsync<StockCheckResponses>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task OrderProduceAsync(OrderEntity order)
        {
            var orderEvent = new OrderCreatedEvent(order.Id, order.ProductId, order.Quantity);

            await _eventPublisher.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = JsonSerializer.Serialize(orderEvent)
            });
        }
    }
}
