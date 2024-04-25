using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IFeallesService
    {
        Task<ResponseDto?> GetFeallesAsync(string feallesname);
        Task<ResponseDto?> GetAllFeallesesAsync();
        Task<ResponseDto?> GetFeallesByIdAsync(int ID);
        Task<ResponseDto?> CreateFeallesAsync(Feallesbase feallesbase);
        Task<ResponseDto?> UpdateFeallesAsync(Feallesbase feallesbase);
        Task<ResponseDto?> DeleteFeallesAsync(int id);
    }
}
