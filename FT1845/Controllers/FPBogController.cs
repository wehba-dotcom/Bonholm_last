using FæsteProtokollerBog.Data;
using FæsteProtokollerBog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FæsteProtokollerBog.Controllers
{
    [Route("api/FPBog")]
    [ApiController]
    public class FPBogController: Controller
    {
      
        private readonly DbContextApplication _db;
        private readonly ResponseDto _response;

        public FPBogController(DbContextApplication db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<FPBog> boge = _db.FæsteProtokollerBog.ToList();
                _response.Result = boge;

            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{ID:int}")]
        public ResponseDto GetById(int ID)
        {
            try
            {
                FPBog? obj = _db.FæsteProtokollerBog.First(x=> x.ID==ID);
                _response.Result = obj;

            }catch(Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }


    }
}
