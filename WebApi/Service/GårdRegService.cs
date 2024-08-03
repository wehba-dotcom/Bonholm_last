using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
   
    public class GårdRegService : IGårdReg
    {
        private readonly IBaseService _baseService;
        public GårdRegService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(GårdReg gårdReg)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = gårdReg,
                Url = SD.GårdRegApiBase + "/api/gårdreg"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.GårdRegApiBase + "/api/gårdreg/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync(string? Fornavne, string? Efternavn, string? ÆgtefællesFornavne, string? ÆgtefællesEfternavn)
        {
            var query = new Dictionary<string, string>
            {
                { "Fornavne", Fornavne },
                { "Efternavn", Efternavn },
                { "ÆgtefællesFornavne", ÆgtefællesFornavne },
                { "ÆgtefællesEfternavn", ÆgtefællesEfternavn }
                
            };

            var queryString = string.Join("&", query.Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                                                     .Select(kvp => $"{kvp.Key}={kvp.Value}"));
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.GårdRegApiBase}/api/gårdreg?{queryString}"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.GårdRegApiBase + "/api/gårdreg/" + ID
            });
        }

        public async Task<ResponseDto?> UpdateAsync(GårdReg gårdReg)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = gårdReg,
                Url = SD.GårdRegApiBase + "/api/gårdreg",
                //ContentType = SD.ContentType.MultipartFormData
            }); throw new NotImplementedException();
        }
    }
}
