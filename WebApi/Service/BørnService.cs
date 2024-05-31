using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class BørnService : IBørn
    {
        private readonly IBaseService _baseService;
        public BørnService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(Børn børn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = børn,
                Url = SD.BornAPIBase + "/api/born"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.BornAPIBase + "/api/born/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BornAPIBase + "/api/born/"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BornAPIBase + "/api/born/" + ID
            });
        }

        public async Task<ResponseDto?> GetByNameAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BornAPIBase + "/api/born/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> UpdateAsync(Børn børn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = børn,
                Url = SD.BornAPIBase + "/api/born",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
