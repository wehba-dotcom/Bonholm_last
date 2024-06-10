using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class FtService : IFt
    {
        private readonly IBaseService _baseService;
        public FtService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(FT ft)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = ft,
                Url = SD.FtAPIBase + "/api/ft"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.FtAPIBase + "/api/ft/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FtAPIBase + "/api/ft/"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FtAPIBase + "/api/ft/" + ID
            });
        }

        public async Task<ResponseDto> GetByNameAsync(string Fornavne)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FtAPIBase + "/api/ft/search/" + Fornavne
            });
        }

        public async Task<ResponseDto?> UpdateAsync(FT ft)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = ft,
                Url = SD.FtAPIBase + "/api/ft",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
