using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Utility;
using WebApi.Models;

namespace WebApi.Service
{
    public class FotoService : IFoto
    {
        private readonly IBaseService _baseService;
        public FotoService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(Foto foto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = foto,
                Url = SD.FotoAPIBase + "/api/foto"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.FotoAPIBase + "/api/foto/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FotoAPIBase + "/api/foto/"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FotoAPIBase + "/api/foto/" + ID
            });
        }

        public async Task<ResponseDto> GetByNameAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FotoAPIBase + "/api/foto/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> UpdateAsync(Foto foto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = foto,
                Url = SD.FotoAPIBase + "/api/foto",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
