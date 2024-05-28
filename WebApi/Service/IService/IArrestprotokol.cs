using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IArrestprotokol
    {
        Task<ResponseDto?> GetArrestprotokolByNameAsync(string Fornavn);
        Task<ResponseDto?> GetAllArrestprotokolsAsync();
        Task<ResponseDto?> GetArrestprotokolByIdAsync(int ID);
        Task<ResponseDto?> CreateArrestprotokolAsync(Arrestprotokoller arrestprotokoller);
        Task<ResponseDto?> UpdateArrestprotokolAsync(Arrestprotokoller arrestprotokoller);
        Task<ResponseDto?> DeleteArrestprotokolAsync(int ID);
    }
}
