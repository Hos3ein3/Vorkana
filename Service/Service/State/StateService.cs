using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class StateService:GenericService<Data.Entites.State> , IStateService
    {
        private readonly Data.Entites.State state;
        public StateService(Data.Entites.State _state)
        {
            state = _state;
        }
    }
}
