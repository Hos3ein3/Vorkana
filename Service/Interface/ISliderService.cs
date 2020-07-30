using Data.Entites;
using Data.Entites.ResultStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    interface ISliderService : IGenericService<Slider>
    {
        Task<Tuple<Slider, ResultStatus>> FillModel(Slider slider);

    }
}
