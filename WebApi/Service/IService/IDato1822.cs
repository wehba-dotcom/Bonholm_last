using WebApi.SharedModels;
using WebApi.Models;


namespace WebApi.Service.IService
{
    public interface IDato1822
    {
        Task<ResponseDto?> GetDatoByNameAsync(string Fornavn);
        Task<ResponseDto?> GetAllDatosAsync();
        Task<ResponseDto?> GetDatoByIdAsync(int ID);
        Task<ResponseDto?> CreateDatoAsync(Dato1822 dato);
        Task<ResponseDto?> UpdateDatoAsync(Dato1822 dato);
        Task<ResponseDto?> DeleteDatoAsync(int ID);
        
    }
}
