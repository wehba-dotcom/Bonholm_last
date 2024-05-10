using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IAfgangTilgangService
    {
        Task<ResponseDto?> GetAfgansAsync(string feallesname);
        Task<ResponseDto?> GetAllAfgangsAsync();
        Task<ResponseDto?> GetAfgangsByIdAsync(int id);
        Task<ResponseDto?> CreateAfgangsAsync(AfgangTilgang afgangTilgang);
        Task<ResponseDto?> UpdateAfgangsAsync(AfgangTilgang afgangTilgang);
        Task<ResponseDto?> DeleteAfgangsAsync(int ID);
    }
}
