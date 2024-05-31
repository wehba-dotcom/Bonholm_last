using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IBørn
    {
        Task<ResponseDto> GetByNameAsync(string Fornavn);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(Børn børn);
        Task<ResponseDto?> UpdateAsync(Børn børn);
        Task<ResponseDto?> DeleteAsync(int ID);
    }
}
