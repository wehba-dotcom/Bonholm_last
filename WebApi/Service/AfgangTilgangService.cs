using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class AfgangTilgangService : IAfgangTilgangService
    {
        private readonly IBaseService _baseService;
        public AfgangTilgangService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAfgangsAsync(AfgangTilgang afgangTilgang)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = afgangTilgang,
                Url = SD.AfgangTilgangAPIBase + "/api/afgangtilgang"
            });
        }

        public async Task<ResponseDto?> DeleteAfgangsAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AfgangTilgangAPIBase + "/api/afgangtilgang/" + ID
            });
        }

        public async Task<ResponseDto?> GetAfgangsByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AfgangTilgangAPIBase + "/api/afgangtilgang/"+ id
            });
        }

        public async Task<ResponseDto?> GetAfgansAsync(string afgangsname)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AfgangTilgangAPIBase + "/api/afgangtilgang/GetByCode/" + afgangsname
            });
        }

        public async Task<ResponseDto?> GetAllAfgangsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AfgangTilgangAPIBase + "/api/afgangtilgang/" 
            });
        }

        public async Task<ResponseDto?> UpdateAfgangsAsync(AfgangTilgang afgangTilgang)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = afgangTilgang,
                Url = SD.AfgangTilgangAPIBase + "/api/afgangtilgang",
                //ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
