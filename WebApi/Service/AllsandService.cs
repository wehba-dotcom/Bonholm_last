using WebApi.SharedModels;
using WebApi.Models;
using WebApi.Service.IService;
using WebApi.Utility;

namespace WebApi.Service
{
    public class AllsandService : IAllsand
    {

        private readonly IBaseService _baseService;
        public AllsandService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAllsandAsync(Allsand allsand)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = allsand,
                Url = SD.AllsandAPIBase + "/api/allsand"
            });
        }

        public async Task<ResponseDto?> DeleteAllsandAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AllsandAPIBase + "/api/allsand/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsandssAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AllsandAPIBase + "/api/allsand/"
            });
        }

        public async Task<ResponseDto?> GetAllsandAsync(string allsandName)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AllsandAPIBase + "/api/allsand/GetByCode/" + allsandName
            });
        }

        public async Task<ResponseDto?> GetAllsandByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AllsandAPIBase + "/api/allsand/" + id
            });
        }

        public async Task<ResponseDto?> UpdateAllsandAsync(Allsand allsand)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = allsand,
                Url = SD.AllsandAPIBase + "/api/allsand",
                //ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
