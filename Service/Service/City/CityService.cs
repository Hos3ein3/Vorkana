using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Service.Interface;

namespace Service.Service
{
    public class CityService : GenericService<City>, ICityService
    {
        private readonly City _city;
        public CityService(City city)
        {
            _city = city;
        }
    }
}
