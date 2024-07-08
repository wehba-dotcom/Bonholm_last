using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class FPBogService : IFPBog
    {
        private readonly IBaseService _baseService;
        public FPBogService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(FPBog fpbog)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = fpbog,
                Url = SD.FPBogApiBase + "/api/fpbog"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.FPBogApiBase + "/api/fpbog/" + ID
            });
        }

        public async Task<ResponseDto?> GetAllAsync(string? Fornavn, string? Efternavn, string? ForrigeFaesterFornavn, string? ForrigeFaesterEfternavn, string? Gaard, string? Sogn)
        {
            var query = new Dictionary<string, string>
            {
                { "Fornavn", Fornavn },
                { "Efternavn", Efternavn },
                { "ForrigeFaesterFornavn", ForrigeFaesterFornavn },
                { "ForrigeFaesterEfternavn", ForrigeFaesterEfternavn },
                { "Gaard", Gaard },
                { "Sogn", Sogn }
            };

            var queryString = string.Join("&", query.Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                                                     .Select(kvp => $"{kvp.Key}={kvp.Value}"));
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.FPBogApiBase}/api/fpbog?{queryString}"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FPBogApiBase + "/api/fpbog/" + ID
            });
        }


        public Task<ResponseDto?> UpdateAsync(FPBog fpbog)
        {
            throw new NotImplementedException();
        }
    }
}
