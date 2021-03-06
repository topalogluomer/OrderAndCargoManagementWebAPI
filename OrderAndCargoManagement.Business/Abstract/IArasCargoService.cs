using OrderAndCargoManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndCargoManagement.Business.Abstract
{
    public interface IArasCargoService
    {
        Task<List<ArasCargo>> GetAllOrders();
        Task<ArasCargo> GetOrderById(int id);
        Task<ArasCargo> GetOrderByName(string name);
        Task<ArasCargo> CreateOrder(ArasCargo clothingOrder);
        //Task<ArasCargo> UpdateOrder(ArasCargo clothingOrder);
        Task CanceleOrder(int id);
    }
}
