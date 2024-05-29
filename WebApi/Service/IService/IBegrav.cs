using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IBegrav
    {
        Task<ResponseDto?> GetByNameAsync(string Fornavn);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(Begrav begrav);
        Task<ResponseDto?> UpdateAsync(Begrav begrav);
        Task<ResponseDto?> DeleteAsync(int ID);
    }
}
