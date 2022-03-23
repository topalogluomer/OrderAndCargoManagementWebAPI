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
    public class ArasCargoRepository : IArasCargoRepository

    {
        public async Task<ArasCargo> CreateOrder(ArasCargo clothingOrder)
        {
            using (var orderDbContext=new OrderDbContext())
            {
                orderDbContext.arasCargos.Add(clothingOrder);
                await orderDbContext.SaveChangesAsync();
                return clothingOrder;
            }
        }

        public async Task CanceleOrder(int id)
        {
            using(var orderDbContext=new OrderDbContext())
            {
                var canceledOrder= await GetOrderById(id);
                orderDbContext.arasCargos.Remove(canceledOrder);
                await orderDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ArasCargo>> GetAllOrders()
        {
            using(var orderDbContext=new OrderDbContext())
            {
                return await orderDbContext.arasCargos.ToListAsync();
            }
        }

        public async Task<ArasCargo> GetOrderById(int id)
        {
            using( var orderDbContext=new OrderDbContext())
            {
                return await orderDbContext.arasCargos.FindAsync(id); 
            }
        }

        public async Task<ArasCargo> GetOrderByName(string name)
        {
            using (var orderDbContext=new OrderDbContext())
            {
                return await orderDbContext.arasCargos.FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());
            }
        }

        public async Task<ArasCargo> UpdateOrder(ArasCargo clothingOrder)
        {
            using(var orderDbContext=new OrderDbContext())
            {
                orderDbContext.arasCargos.Update(clothingOrder);
                await orderDbContext.SaveChangesAsync();
                return clothingOrder;
            }
        }
    }
}
