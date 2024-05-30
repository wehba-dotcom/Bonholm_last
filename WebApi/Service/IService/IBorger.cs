using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IBorger
    {

        Task<ResponseDto?> GetByNameAsync(string Fornavn);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(Borger borger);
        Task<ResponseDto?> UpdateAsync(Borger borger);
        Task<ResponseDto?> DeleteAsync(int ID);
    }
}
