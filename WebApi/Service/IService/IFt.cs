using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IFt
    {
        Task<ResponseDto> GetByNameAsync(string Fornavne);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(FT ft);
        Task<ResponseDto?> UpdateAsync(FT ft);
        Task<ResponseDto?> DeleteAsync(int ID);
    }
}
