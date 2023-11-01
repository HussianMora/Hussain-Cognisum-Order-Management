using OrderBL.Interface;
using OrderDAL;
using OrderDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBL
{
    public class OrderBAL : IOrderBAL
    {
        private readonly IOrderDL _orderRepository;

        public OrderBAL(IOrderDL orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task AddOrderAsync(Order order)
        {
            // You can implement any business logic here if needed
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            // You can implement any business logic here if needed
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            // You can implement any business logic here if needed
            await _orderRepository.DeleteOrderAsync(orderId);
        }
    }
}
