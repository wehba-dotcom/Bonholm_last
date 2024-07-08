using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IFPBog
    {
    
        Task<ResponseDto?> GetAllAsync(string? Fornavn, string? Efternavn, string? ForrigeFaesterFornavn, string? ForrigeFaesterEfternavn, string? Gaard, string? Sogn);
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(FPBog fpbog);
        Task<ResponseDto?> UpdateAsync(FPBog fpbog);
        Task<ResponseDto?> DeleteAsync(int ID);
    }
}
