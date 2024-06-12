using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class FeallesService : IFeallesService
    {
        private readonly IBaseService _baseService;
        public FeallesService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateFeallesAsync(Feallesbase feallesbase)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=feallesbase,
                Url = SD.FeallesAPIBase + "/api/feallesbase" 
            });
        }

        public async Task<ResponseDto?> DeleteFeallesAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.FeallesAPIBase + "/api/feallesbase/" + ID
            }); 
        }

        public async Task<ResponseDto?> GetAllFeallesesAsync(string? fornavne, string? efternavn, string? doebenavn, DateTime? doedsdato, string? begravelsessted, string? efterladte)
        {
            var query = new Dictionary<string, string>
            {
                { "Fornavne", fornavne },
                { "Efternavn", efternavn },
                { "Doebenavn", doebenavn },
                { "Doedsdato", doedsdato?.ToString("yyyy-MM-dd") },
                { "Begravelsessted", begravelsessted },
                { "Efterladte", efterladte }
            };

            var queryString = string.Join("&", query.Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                                                     .Select(kvp => $"{kvp.Key}={kvp.Value}"));
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.FeallesAPIBase}/api/feallesbase?{queryString}"
            });
        }

        public async Task<ResponseDto?> Search(string? fornavne, string? efternavn, string? doebenavn, DateTime? doedsdato, string? begravelsessted, string? efterladte)
        {
            var query = new Dictionary<string, string>
            {
                { "Fornavne", fornavne },
                { "Efternavn", efternavn },
                { "Doebenavn", doebenavn },
                { "Doedsdato", doedsdato?.ToString("yyyy-MM-dd") },
                { "Begravelsessted", begravelsessted },
                { "Efterladte", efterladte }
            };

            var queryString = string.Join("&", query.Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                                                     .Select(kvp => $"{kvp.Key}={kvp.Value}"));
            return await _baseService.SendAsync(new RequestDto()
            {
              
                ApiType = SD.ApiType.GET,
                Url = $"{SD.FeallesAPIBase}/api/feallesbase/search?{queryString}"
            });
        }

        public async Task<ResponseDto?> GetFeallesByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FeallesAPIBase + "/api/feallesbase/" + ID
            });
        }

        public async Task<ResponseDto?> UpdateFeallesAsync(Feallesbase feallesbase)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = feallesbase,
                Url = SD.FeallesAPIBase + "/api/feallesbase",
                //ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
