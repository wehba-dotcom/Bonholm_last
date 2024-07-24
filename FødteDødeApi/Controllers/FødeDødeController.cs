using FødteDødeApi.Data;
using FødteDødeApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FødteDødeApi.Controllers
{
    [Route("api/fødtedøde")]
    [ApiController]
    public class FødeDødeController:Controller
    {
        private readonly DbAppContext _db;
        private readonly ResponseDto _resDto;
        public FødeDødeController(DbAppContext db)
        {
            _db = db;
            _resDto = new ResponseDto();

        }



        [HttpGet]
        public ResponseDto GetAll(string? Fornavne, string? Efternavn, string? Slægtsnavn, string? Født, string? Fødesogn, string? Død,string? Dødssted)
        {
            var fødtedøde = from b in _db.FødteDøde select b;
            try
            {
                if (!String.IsNullOrEmpty(Fornavne))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.fornavne == Fornavne);
                }
                if (!String.IsNullOrEmpty(Efternavn))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.Efternavn == Efternavn);
                }
                if (!String.IsNullOrEmpty(Slægtsnavn))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.Slægtsnavn == Slægtsnavn);
                }
                if (!String.IsNullOrEmpty(Født))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.Født == Født);
                }
                if (!String.IsNullOrEmpty(Fødesogn))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.Fødesogn == Fødesogn);
                }
                if (!String.IsNullOrEmpty(Død))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.Død == Død);
                }
                if (!String.IsNullOrEmpty(Dødssted))
                {
                    fødtedøde = _db.FødteDøde.Where(x => x.Dødssted == Dødssted);
                }
                _resDto.Result = fødtedøde.ToList();
                _resDto.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _resDto.IsSuccess = false;
                _resDto.Message = ex.Message;
            }
            return _resDto;
        }
    }
}
