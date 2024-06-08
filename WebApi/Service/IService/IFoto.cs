using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IFoto
    {
        Task<ResponseDto> GetByNameAsync(string Fornavn);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(Foto foto);
        Task<ResponseDto?> UpdateAsync(Foto foto);
        Task<ResponseDto?> DeleteAsync(int ID);
    }
}
