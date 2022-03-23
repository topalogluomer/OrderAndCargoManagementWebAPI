using OrderAndCargoManagement.DataAccess.Abstract;
using OrderAndCargoManagement.DataAccess.Concrete;
using OrderAndCargoManagement.Entities;
using OrderAndCargoManagement.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndCargoManagement.Business.Concrete
{
   
    public class YurticiCargoManager : IYurticiCargoService
    {
        private IYurticiCargoRepository _yurticiCargoRepository;
        public YurticiCargoManager()
        {
            _yurticiCargoRepository = new YurticiCargoRepository();
        }


        public async Task CanceleOrder(int id)
        {
             await _yurticiCargoRepository.CanceleOrder(id);
        }

        public Task<YurticiCargo> CreateOrder(YurticiCargo foodOrder)
        {
            return _yurticiCargoRepository.CreateOrder(foodOrder);
        }

        public async Task<List<YurticiCargo>> GetAllOrders()
        {
            return await _yurticiCargoRepository.GetAllOrders();
        }

        public async Task<YurticiCargo> GetOrderById(int id)
        {
            if (id>0)
            {
                return await _yurticiCargoRepository.GetOrderById(id);

            }
            throw new Exception("id cannot be less than 1");
        }

        public async Task<YurticiCargo> GetOrderByName(string name)
        {
            if (name != null)
            {
                return await _yurticiCargoRepository.GetOrderByName(name);
            }
            throw new Exception("Order name was not found");
        }

        //public async Task<YurticiCargo> UpdateOrder(YurticiCargo foodOrder)
        //{
        //    return await UpdateOrder(foodOrder);
        //}
    }
}
