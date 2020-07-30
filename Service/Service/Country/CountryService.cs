using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class CountryService:GenericService<Data.Entites.Country> , ICountryService
    {
        private readonly Data.Entites.Country country;
        public CountryService(Data.Entites.Country _country)
        {
            country = _country;
        }
    }
}
