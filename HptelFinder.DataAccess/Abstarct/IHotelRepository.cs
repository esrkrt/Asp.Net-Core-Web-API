﻿using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HptelFinder.DataAccess.Abstarct
{
  public  interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotel();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> GetHotelByName(string name);
        Task<Hotel> CreateHotel(Hotel hotel);
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);
    }
}
