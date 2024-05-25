using WebApi.SharedModels;
using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IAllsand
    {
        Task<ResponseDto?> GetAllsandAsync(string Fornavn);
        Task<ResponseDto?> GetAllAsandssAsync();
        Task<ResponseDto?> GetAllsandByIdAsync(int id);
        Task<ResponseDto?> CreateAllsandAsync(Allsand allsand);
        Task<ResponseDto?> UpdateAllsandAsync(Allsand allsand);
        Task<ResponseDto?> DeleteAllsandAsync(int ID);
        
    }
}
