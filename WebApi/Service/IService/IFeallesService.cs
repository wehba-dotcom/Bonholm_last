using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IFeallesService
    {
        Task<ResponseDto?> Search(string? fornavne, string? efternavn, string? doebenavn, DateTime? doedsdato, string? begravelsessted, string? efterladte);
        Task<ResponseDto?> GetAllFeallesesAsync(string? Fornavne, string? Efternavn, string? Doebenavn, DateTime? Doedsdato, string? Begravelsessted, string? Efterladte);
        Task<ResponseDto?> GetFeallesByIdAsync(int ID);
        Task<ResponseDto?> CreateFeallesAsync(Feallesbase feallesbase);
        Task<ResponseDto?> UpdateFeallesAsync(Feallesbase feallesbase);
        Task<ResponseDto?> DeleteFeallesAsync(int id);
    }
}
