using Common.Enumeration;
using Data.Entities.ResultStatus;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Common.GenericController;
using Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Common.FileUploader;

namespace Service.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        
        protected readonly GenericRepository<T> genericRepository;

        public virtual IPagedList<T> Pagination(IQueryable<T> specification = null, bool isExportPageList = true, int pageNumber = 1, int pageSize = 10, bool isDesc = true, string sortColumn = "")
        {
            IPagedList<T> resultList;
            var sortColumnParam = "Id";
            if (!string.IsNullOrWhiteSpace(sortColumn))
            {
                sortColumnParam = sortColumn;
            }

            var propertyInfo = typeof(T).GetProperty(sortColumnParam);

            var query = specification == null ? genericRepository.GetAll() : specification;
          

            if (isDesc)
                resultList = query.AsEnumerable().OrderByDescending(x => propertyInfo.GetValue(x, null)).ToPagedList<T>(pageNumber, pageSize);
            else
                resultList = query.AsEnumerable().OrderBy(x => propertyInfo.GetValue(x, null)).ToPagedList<T>(pageNumber, pageSize);

            return resultList;
        }
        public virtual IPagedList<T> Pagination(IQueryable<T> specification = null, int pageNumber = 1, int pageSize = 10)
        {
            IPagedList<T> resultList;
            var query = specification == null ? genericRepository.GetAll() : specification;
            
            resultList = query.ToPagedList<T>(pageNumber, pageSize);

            return resultList;
        }
        public virtual async Task<Tuple<T, ResultStatus>> Find(int Id)
        {
            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                T model = await genericRepository.GetByIdAsync(Id);

                if (model != null)
                {
                    resultStatus.Message = "رکورد باموفقیت بازیابی شد";
                    resultStatus.IsSuccessed = true;
                    resultStatus.Type = MessageType.Success;
                    return Tuple.Create(model, resultStatus);
                }
                else
                {
                    resultStatus.Message = "رکورد یافت نشد";
                    resultStatus.IsSuccessed = false;
                    resultStatus.Type = MessageType.Success;
                    return Tuple.Create(model, resultStatus);
                }

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
        public virtual async Task<Tuple<T, ResultStatus>> FindInclude(int id, IQueryable<T> specification = null)
        {
            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                var query = specification == null ? genericRepository.GetAll() : specification;
                T model = query.AsEnumerable().Where(x => x.GetType().GetProperty("Id").GetValue(x) != null && x.GetType().GetProperty("Id").GetValue(x).ToString().Equals(id.ToString())).FirstOrDefault();

                if (model != null)
                {
                    resultStatus.Message = "رکورد باموفقیت بازیابی شد";
                    resultStatus.IsSuccessed = true;
                    resultStatus.Type = MessageType.Success;
                    return Tuple.Create(model, resultStatus);
                }
                else
                {
                    resultStatus.Message = "رکورد یافت نشد";
                    resultStatus.IsSuccessed = false;
                    resultStatus.Type = MessageType.Warning;
                    return Tuple.Create(model, resultStatus);
                }

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
        public virtual async Task<Tuple<T, ResultStatus>> Add(ControllerInfo controllerInfo, T model)
        {
            ResultStatus resultStatus = new ResultStatus();
            resultStatus.Type = MessageType.Success;
            resultStatus.IsSuccessed = true;

            try
            {
                if (model == null)
                {
                    resultStatus.Type = MessageType.Warning;
                    resultStatus.IsSuccessed = false;
                    resultStatus.Message = "مدل خالی است";
                    return Tuple.Create(model, resultStatus);
                }
                if (!controllerInfo.ModelState.IsValid)
                {
                    resultStatus.Type = MessageType.Warning;
                    resultStatus.IsSuccessed = false;
                    resultStatus.Message = "اطلاعات کامل نیست";
                    return Tuple.Create(model, resultStatus);
                }

                genericRepository.Add(model);
                await genericRepository.SaveAsync();
                resultStatus.Type = MessageType.Success;
                resultStatus.Message = "اطلاعات با موفقیت ثبت شد";
                return Tuple.Create(model, resultStatus);
            }
            catch (Exception exception)
            {
                resultStatus.IsSuccessed = false;
                resultStatus.Message = "خطایی رخ داده است";
                resultStatus.Type = MessageType.Danger;
                resultStatus.ErrorException = exception;
                return Tuple.Create(model, resultStatus);
            }
        }
        public virtual async Task<Tuple<T, ResultStatus>> Edit(ControllerInfo controllerInfo, T model)
        {
            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                if (model == null)
                {
                    resultStatus.Message = "رکورد یافت نشد";
                    resultStatus.IsSuccessed = false;
                    resultStatus.Type = MessageType.Warning;
                    return Tuple.Create(model, resultStatus);
                }
                if (!controllerInfo.ModelState.IsValid)
                {
                    resultStatus.Message = "اطلاعات کامل نیست";
                    resultStatus.IsSuccessed = false;
                    resultStatus.Type = MessageType.Warning;
                    return Tuple.Create(model, resultStatus);
                }

                genericRepository.Update(model);
                await genericRepository.SaveAsync();
                resultStatus.Type = MessageType.Success;
                resultStatus.Message = "اطلاعات با موفقیت بروزرسانی شد";
                return Tuple.Create(model, resultStatus);
            }
            catch (Exception exception)
            {
                resultStatus.IsSuccessed = false;
                resultStatus.Message = "خطایی رخ داده است";
                resultStatus.Type = MessageType.Danger;
                resultStatus.ErrorException = exception;
                return Tuple.Create(model, resultStatus);
            }

        }
        public virtual async Task<ResultStatus> Delete(int Id)
        {
            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                T model = await genericRepository.GetByIdAsync(Id);
                if (model != null)
                {
                    genericRepository.Delete(model);
                    await genericRepository.SaveAsync();
                }
                else
                {
                    resultStatus.IsSuccessed = false;
                    resultStatus.Message = "رکورد یافت نشد";
                    resultStatus.Type = MessageType.Warning;
                }

                return resultStatus;
            }
            catch (Exception exception)
            {
                resultStatus.IsSuccessed = false;
                resultStatus.Message = "خطایی رخ داده است";
                resultStatus.Type = MessageType.Danger;
                resultStatus.ErrorException = exception;
                return resultStatus;
            }
        }
        public virtual async Task<ResultStatus> SaveAsync()
        {

            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                await genericRepository.SaveAsync();
                return resultStatus;
            }
            catch (Exception exception)
            {
                resultStatus.IsSuccessed = false;
                resultStatus.Message = "خطایی رخ داده است";
                resultStatus.Type = MessageType.Danger;
                resultStatus.ErrorException = exception;
                return resultStatus;
            }
        }
        public virtual ResultStatus Save()
        {
            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                genericRepository.Save();
                return resultStatus;
            }
            catch (Exception exception)
            {
                resultStatus.IsSuccessed = false;
                resultStatus.Message = "خطایی رخ داده است";
                resultStatus.Type = MessageType.Danger;
                resultStatus.ErrorException = exception;
                return resultStatus;
            }
        }
        public async Task<ResultStatus> UploadFiles(IFormFile file, FileType fileType, bool isDeleteFile, string fileName, string hostingEnvironmentWebRootPath, string path, string modelId, string fileExtensions, int maxSize = 0, int width = 0, int height = 0)
        {

            ResultStatus resultStatus = new ResultStatus();
            resultStatus.IsSuccessed = true;
            resultStatus.Type = MessageType.Success;

            try
            {
                path = hostingEnvironmentWebRootPath + path + modelId;
                Directory.CreateDirectory(path);
                path = path + "\\" + fileName;

                if (file != null)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    if (fileType == FileType.Image)
                    {
                        GenericFileUploader.UploadImage(file, path, fileExtensions, 0, 0, 0);
                    }
                    else if (fileType == FileType.Video)
                    {
                        GenericFileUploader.UploadVideo(file, path, fileExtensions, 0);
                    }
                    else if (fileType == FileType.Sound)
                    {
                        GenericFileUploader.UploadSound(file, path, fileExtensions, 0);
                    }
                    else if (fileType == FileType.Document)
                    {
                        GenericFileUploader.UploadDocument(file, path, fileExtensions, 0);
                    }
                    else if (fileType == FileType.Zip)
                    {
                        GenericFileUploader.UploadZip(file, path, fileExtensions, 0);
                    }
                    else
                    {
                        GenericFileUploader.UploadFiles(file, path, fileExtensions, 0);
                    }
                }
                else if (isDeleteFile)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }


                return resultStatus;
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
