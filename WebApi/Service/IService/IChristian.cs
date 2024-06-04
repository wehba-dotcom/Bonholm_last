using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IChristian
    {
        Task<ResponseDto?> GetAsync(string Fornavn);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int id);
        Task<ResponseDto?> CreateAsync(Christiansø christiansø);
        Task<ResponseDto?> UpdateAsync(Christiansø christiansø);
        Task<ResponseDto?> DeleteAsync(int ID);
        
    }
}
