using Common.Enumeration;
using Common.GenericController;
using Data.Entities.ResultStatus;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Interface
{
    public interface IGenericService<T> where T : class
    {
        IPagedList<T> Pagination(IQueryable<T> specification = null, bool isExportPageList = true, int pageNumber = 1, int pageSize = 10, bool isDesc = true, string sortColumn = "");
        IPagedList<T> Pagination(IQueryable<T> specification = null, int pageNumber = 1, int pageSize = 10);
        Task<Tuple<T, ResultStatus>> Find(int Id);
        Task<Tuple<T, ResultStatus>> FindInclude(int id, IQueryable<T> specification = null);
        Task<Tuple<T, ResultStatus>> Add(ControllerInfo controllerInfo, T model);
        Task<Tuple<T, ResultStatus>> Edit(ControllerInfo controllerInfo, T model);
        Task<ResultStatus> Delete(int Id);
        Task<ResultStatus> SaveAsync();
        ResultStatus Save();
        Task<ResultStatus> UploadFiles(IFormFile file, FileType fileType, bool isDeleteImage, string fileName, string hostingEnvironmentWebRootPath, string path, string modelId, string fileExtensions, int maxSize = 0, int width = 0, int height = 0);
    }
}
