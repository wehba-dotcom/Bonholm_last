using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class DatoService : IDato1822
    {
        private readonly IBaseService _baseService;
        public DatoService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateDatoAsync(Dato1822 dato)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dato,
                Url = SD.DatoAPIBase + "/api/dato"
            });
        }

        public  async Task<ResponseDto?> DeleteDatoAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.DatoAPIBase + "/api/dato/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllDatosAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DatoAPIBase + "/api/dato/"
            });
        }

        public async Task<ResponseDto?> GetDatoByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DatoAPIBase + "/api/dato/" + ID
            });
        }

        public async Task<ResponseDto?> GetDatoByNameAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DatoAPIBase + "/api/dato/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> UpdateDatoAsync(Dato1822 dato)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dato,
                Url = SD.DatoAPIBase + "/api/dato",
                //ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
