using System;
using System.Collections.Generic;
using System.Text;
using Data.Entites;
using Service.Interface;

namespace Service.Service
{
    public class CityService:GenericService<Data.Entites.City>,ICityService
    {
        private readonly Data.Entites.City city;
        public CityService(Data.Entites.City _city)
        {
            city = _city;
        }
    }
}
