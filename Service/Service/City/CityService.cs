using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Service.Interface;

namespace Service.Service
{
    public class CityService:GenericService<City>,ICityService
    {
        private readonly City city;
        public CityService(City _city)
        {
            city = _city;
        }
    }
}
