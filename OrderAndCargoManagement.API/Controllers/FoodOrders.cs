using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAndCargoManagement.Entities;
using OrderAndCargoManagement.Business.Abstract;
using OrderAndCargoManagement.Business.Concrete;
using System.Threading.Tasks;
using OrderAndCargoManagement.API.Models;

namespace OrderAndCargoManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrders : ControllerBase
    {
        private IYurticiCargoService _yurticiCargoService;
        //atamalarımı yaptım
        public FoodOrders()
        {
            _yurticiCargoService = new YurticiCargoManager();
        }
        //gıda siparislerimin hepsini görmek icin
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllFoodOrders()
        {
            var foodOrder = await _yurticiCargoService.GetAllOrders();

            return Ok(foodOrder);

        }

        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetFoodOrderById(int id)
        {
            var foodOrder = await _yurticiCargoService.GetOrderById(id);
            if (foodOrder != null)
            {
                return Ok(foodOrder);

            }
            return NotFound();

        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetFoodOrderByName(string name)
        {
            var foodOrder = await _yurticiCargoService.GetOrderByName(name);
            if (foodOrder != null)
            {
                return Ok(foodOrder);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateFoodOrder([FromBody] YurticiCargo order)
        {
            var FoodOrder = await _yurticiCargoService.CreateOrder(order);

            return CreatedAtAction("GetAllFoodOrders", new { id = FoodOrder.Id }, FoodOrder);
        }
        //[HttpPut]
        //[Route("[action]/{id}")]
        //public async Task<IActionResult> UpdateFoodOrder([FromBody] YurticiCargo order)
        //{
        //    if (await _yurticiCargoService.GetOrderById(order.Id) != null)
        //    {
        //        return Ok(await _yurticiCargoService.UpdateOrder(order));
        //    }
        //    return NotFound();
        //}
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> CanceleFoodOrder(int id)
        {
            if (await _yurticiCargoService.GetOrderById(id) != null)
            {
                await _yurticiCargoService.CanceleOrder(id);
                ResultStatus status= ResultStatus.Pending;
                if (status==ResultStatus.Pending)
                {
                    return BadRequest();
                }
                await _yurticiCargoService.CanceleOrder(id);

                return Ok();

            }
            return NotFound("Order was not found");
        }
       
    }
}
