using HotelFinder.Business.Abstarct;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels =await _hotelService.GetAllHotel();
            return Ok(hotels);//200+data
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel= await _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel);//200+data
            }
            return NotFound();//404
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);//200+data
            }
            return NotFound();//404
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHotelByIdName(int id, string name)
        {
            
                return Ok();//200+data
           

        }
        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody]Hotel hotel)
        {
                var createHotel = await _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel);//201+data
         
        }
        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel));//200+Data
            }
            return NotFound();
            
        }
        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await  _hotelService.DeleteHotel(id);
                return Ok();//200+Data
            }
            return NotFound();
        }
    }
}
