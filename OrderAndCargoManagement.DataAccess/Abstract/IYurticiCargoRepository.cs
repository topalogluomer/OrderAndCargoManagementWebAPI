using OrderAndCargoManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndCargoManagement.DataAccess.Abstract
{
    public interface IYurticiCargoRepository
    {
        Task<List<YurticiCargo>> GetAllOrders();
        Task<YurticiCargo> GetOrderById(int id);
        Task<YurticiCargo> GetOrderByName(string name);
        Task<YurticiCargo> CreateOrder(YurticiCargo foodOrder);
        Task<YurticiCargo> UpdateOrder(YurticiCargo foodOrder);
        Task CanceleOrder(int id);

    }
}
