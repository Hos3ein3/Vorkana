using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Service.Service
{
    public class CountryService:GenericService<Country> , ICountryService
    {
        private readonly Country country;
        public CountryService(Country _country)
        {
            country = _country;
        }
    }
}
