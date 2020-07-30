using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
    }
}
