using Common.Enumeration;
using Data.Entites;
using Data.Entites.ResultStatus;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SliderService : ISliderService
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


        #region CRUD
        public async Task<Tuple<Slider, ResultStatus>> Add(Slider slider)
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

        public async Task<Tuple<Slider, ResultStatus>> Edit(Slider slider)
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

        public async Task<Tuple<Slider, ResultStatus>> Delete(Slider slider, bool isLogic)
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


        #endregion
    }
}
