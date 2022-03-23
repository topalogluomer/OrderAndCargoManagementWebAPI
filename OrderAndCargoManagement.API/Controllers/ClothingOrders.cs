using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAndCargoManagement.API.Models;
using OrderAndCargoManagement.Business.Abstract;
using OrderAndCargoManagement.Business.Concrete;
using OrderAndCargoManagement.Entities;
using System.Threading.Tasks;

namespace OrderAndCargoManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingOrders : ControllerBase
    {
        private IArasCargoService _arasCargoService;
        public ClothingOrders()
        {
            _arasCargoService = new ArasCargoManager();

        }
        //giyim siparislerimin hepsini görmek icin
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllClothingOrders()
        {
            var clothingOrder = await _arasCargoService.GetAllOrders();

            return Ok(clothingOrder);

        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetClothingOrderById(int id)
        {
            var clothingOrder = await _arasCargoService.GetOrderById(id);
            if (clothingOrder != null)
            {
                return Ok(clothingOrder);

            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetClothingOrderByName(string name)
        {
            var clothingOrder = await _arasCargoService.GetOrderByName(name);
            if (clothingOrder != null)
            {
                return Ok(clothingOrder);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateClothingOrder([FromBody] ArasCargo order)
        {
            var clothingOrder = await _arasCargoService.CreateOrder(order);

            return CreatedAtAction("GetAllClothingOrders", new { id = clothingOrder.Id }, clothingOrder);
        }
        //[HttpPut]
        //[Route("[action]/{id}")]

        //public async Task<IActionResult> UpdateClothingOrder([FromBody] ArasCargo order)
        //{
        //    if (await _arasCargoService.GetOrderById(order.Id) != null)
        //    {
        //        return Ok(await _arasCargoService.UpdateOrder(order));
        //    }
        //    return NotFound();
        //}
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> CanceleClothingOrder(int id)
        {
            if (await _arasCargoService.GetOrderById(id) != null)
            {
                ResultStatus status = ResultStatus.Accepted;
                if (status == ResultStatus.Pending)
                {
                    await _arasCargoService.CanceleOrder(id);
                    return Ok();
                }
               
            }
            return NotFound("Order was not found");
        }

    }
}
