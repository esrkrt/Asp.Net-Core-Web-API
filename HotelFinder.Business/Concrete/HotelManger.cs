using HotelFinder.Business.Abstarct;
using HotelFinder.Entities;
using HptelFinder.DataAccess.Abstarct;
using HptelFinder.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManger : IHotelService
    {
        private IHotelRepository _hotelRepository;
        public HotelManger(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<List<Hotel>> GetAllHotel()
        {
            return await  _hotelRepository.GetAllHotel();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id can not be less than 1");
        }

       

        public async Task<Hotel> GetHotelByName(string name)
        {
            
                return await _hotelRepository.GetHotelByName(name);
           
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
    }
}
