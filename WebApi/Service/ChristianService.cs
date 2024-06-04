using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class ChristianService : IChristian
    {
        private readonly IBaseService _baseService;
        public ChristianService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(Christiansø christiansø)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = christiansø,
                Url = SD.ChristianAPIBase + "/api/christian"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ChristianAPIBase + "/api/christian/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ChristianAPIBase + "/api/christian/"
            });
        }

        public async Task<ResponseDto?> GetAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ChristianAPIBase + "/api/christian/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ChristianAPIBase + "/api/christian/" + ID
            });
        }

       

        public async Task<ResponseDto?> UpdateAsync(Christiansø christiansø)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = christiansø,
                Url = SD.ChristianAPIBase + "/api/christian",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
