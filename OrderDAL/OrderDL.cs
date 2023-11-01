using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL
{
    public class OrderDL : IOrderDL
    {
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task AddOrderAsync(Order order)
        {
            Orders.Add(order);
            await SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            Orders.Update(order);
            await SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await GetOrderByIdAsync(orderId);
            if (order != null)
            {
                Orders.Remove(order);
                await SaveChangesAsync();
            }
        }
    }
}
