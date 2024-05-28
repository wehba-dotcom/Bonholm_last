using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApi.Utility;

namespace WebApi.Service
{
    public class ArrestprotokolService : IArrestprotokol
    {
        private readonly IBaseService _baseService;
        public ArrestprotokolService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateArrestprotokolAsync(Arrestprotokoller arrestprotokoller)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = arrestprotokoller,
                Url = SD.ArrestAPIBase + "/api/arrestprotokoller"
            });
        }

        public async Task<ResponseDto?> DeleteArrestprotokolAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ArrestAPIBase + "/api/arrestprotokoller/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllArrestprotokolsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ArrestAPIBase + "/api/arrestprotokoller/"
            });
        }

        public async Task<ResponseDto?> GetArrestprotokolByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ArrestAPIBase + "/api/arrestprotokoller/" + ID
            });
        }

        public  async Task<ResponseDto?> GetArrestprotokolByNameAsync(string Fornavn)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ArrestAPIBase + "/api/arrestprotokoller/search/" + Fornavn
            });
        }

        public async Task<ResponseDto?> UpdateArrestprotokolAsync(Arrestprotokoller arrestprotokoller)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = arrestprotokoller,
                Url = SD.ArrestAPIBase + "/api/arrestprotokoller",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
