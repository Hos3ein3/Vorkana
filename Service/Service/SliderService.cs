using Common.Enumeration;
using Data.Entities;
using Data.Entities.ResultStatus;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SliderService : GenericService<Slider>,ISliderService
    {
        public async Task<Tuple<Slider, ResultStatus>> FillModel(Slider slider)
        {
			ResultStatus resultStatus = new ResultStatus();
			resultStatus.IsSuccessed = true;
			resultStatus.Type = MessageType.Success;
			try
			{
                return null;
			}
			catch (Exception exception)
			{
                resultStatus.IsSuccessed = false;
                resultStatus.Message = "خطایی رخ داده است";
                resultStatus.Type = MessageType.Danger;
                resultStatus.ErrorException = exception;
                throw new Exception("", exception);
            }
        }
    }
}
