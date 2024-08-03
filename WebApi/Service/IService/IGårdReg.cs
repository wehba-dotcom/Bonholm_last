using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IGårdReg
    {
        
        Task<ResponseDto?> GetAllAsync(string? Fornavne, string? Efternavn, string? ÆgtefællesFornavne, string? ÆgtefællesEfternavn);
        Task<ResponseDto?> GetByIdAsync(int ID);
        Task<ResponseDto?> CreateAsync(GårdReg gårdReg);
        Task<ResponseDto?> UpdateAsync(GårdReg gårdReg);
        Task<ResponseDto?> DeleteAsync(int id);
    }
}
