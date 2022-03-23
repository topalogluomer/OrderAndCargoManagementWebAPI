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
    public class ArasCargoManager : IArasCargoService
    {
        private IArasCargoRepository _arasCargoRepository;
        public ArasCargoManager()
        {
            _arasCargoRepository = new ArasCargoRepository();
        }
        public async Task CanceleOrder(int id)
        {
            await _arasCargoRepository.CanceleOrder(id);
        }

        public async Task<ArasCargo> CreateOrder(ArasCargo clothingOrder)
        {
            return await _arasCargoRepository.CreateOrder(clothingOrder);
        }

        public async Task<List<ArasCargo>> GetAllOrders()
        {
            return await _arasCargoRepository.GetAllOrders();   
        }

        public async Task<ArasCargo> GetOrderById(int id)
        {
            if (id>0)
            {
                return await _arasCargoRepository.GetOrderById(id);

            }
            throw new Exception("Id cannot be less than 1");
        }

        public async Task<ArasCargo> GetOrderByName(string name)
        {
            if (name!=null)
            {
                return await _arasCargoRepository.GetOrderByName(name);

            }
            throw new ArgumentException("Order name was not found");
        }

        //public async Task<ArasCargo> UpdateOrder(ArasCargo clothingOrder)
        //{
        //    return await _arasCargoRepository.UpdateOrder(clothingOrder);
        //}
    }
}
