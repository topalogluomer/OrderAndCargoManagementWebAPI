using Microsoft.EntityFrameworkCore;
using OrderAndCargoManagement.DataAccess.Abstract;
using OrderAndCargoManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndCargoManagement.DataAccess.Concrete
{
    public class YurticiCargoRepository : IYurticiCargoRepository
    {
        public async Task<YurticiCargo> CreateOrder(YurticiCargo foodOrder)
        {
            using (var orderDbContext = new OrderDbContext())
            {
                orderDbContext.yurticiCargos.Add(foodOrder);
                await orderDbContext.SaveChangesAsync();
                return foodOrder;
            }
        }

        public async Task CanceleOrder(int id)
        {
            using (var orderDbContext = new OrderDbContext())
            {
                var canceledOrder = await GetOrderById(id);
                orderDbContext.yurticiCargos.Remove(canceledOrder);
                await orderDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<YurticiCargo>> GetAllOrders()
        {
            using (var orderDbContext = new OrderDbContext())
            {
                return await orderDbContext.yurticiCargos.ToListAsync();
            }
        }

        public async Task<YurticiCargo> GetOrderById(int id)
        {
            using (var orderDbContext = new OrderDbContext())
            {
                return await orderDbContext.yurticiCargos.FindAsync(id);
            }
        }

        public async Task<YurticiCargo> GetOrderByName(string name)
        {
            using (var orderDbContext = new OrderDbContext())
            {
                return await orderDbContext.yurticiCargos.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            }
        }

        public async Task<YurticiCargo> UpdateOrder(YurticiCargo foodOrder)
        {
            using (var orderDbContext = new OrderDbContext())
            {
                orderDbContext.yurticiCargos.Update(foodOrder);
                await orderDbContext.SaveChangesAsync();
                return foodOrder;
            }
        }
    }
}
