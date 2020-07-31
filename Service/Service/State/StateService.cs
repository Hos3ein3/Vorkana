using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Service.Service
{
    public class StateService:GenericService<State> , IStateService
    {
        private readonly State state;
        public StateService(State _state)
        {
            state = _state;
        }
    }
}
