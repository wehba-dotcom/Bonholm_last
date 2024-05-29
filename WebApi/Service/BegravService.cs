using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Utility;
using WebApi.Models;

namespace WebApi.Service
{
    public class BegravService : IBegrav
    {
        private readonly IBaseService _baseService;
        public BegravService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(Begrav begrav)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = begrav,
                Url = SD.BegravAPIBase + "/api/begrav"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.BegravAPIBase + "/api/begrav/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BegravAPIBase + "/api/begrav/"
            });
        }

        public  async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BegravAPIBase + "/api/begrav/" + ID
            });
        }

        public async Task<ResponseDto?> GetByNameAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BegravAPIBase + "/api/begrav/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> UpdateAsync(Begrav begrav)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = begrav,
                Url = SD.BegravAPIBase + "/api/begrav",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
