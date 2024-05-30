using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class BorgerService : IBorger
    {
        private readonly IBaseService _baseService;
        public BorgerService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(Borger borger)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = borger,
                Url = SD.BorgerAPIBase + "/api/borger"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.BorgerAPIBase + "/api/borger/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BorgerAPIBase + "/api/borger/"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BorgerAPIBase + "/api/borger/" + ID
            });
        }

        public async Task<ResponseDto?> GetByNameAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BorgerAPIBase + "/api/borger/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> UpdateAsync(Borger borger)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = borger,
                Url = SD.BorgerAPIBase + "/api/borger",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
