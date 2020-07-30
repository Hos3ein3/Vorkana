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

        Task<Tuple<Slider, ResultStatus>> Add(Slider slider);

        Task<Tuple<Slider, ResultStatus>> Edit(Slider slider);

        Task<Tuple<Slider, ResultStatus>> Delete(Slider slider,bool isLogic);

    }
}
