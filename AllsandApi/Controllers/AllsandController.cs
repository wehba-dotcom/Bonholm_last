using AllsandApi.Data;
using AllsandApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AllsandApi.Controllers
{
    [Route("api/allsand")]
    [ApiController]
    public class AllsandController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        //private IMapper _mapper;
        public AllsandController(AppDbContext db)
        {
            _db = db;
            
            _response = new ResponseDto();

        }



        // GET: api/Allsand
        [HttpGet]
        public ResponseDto GetAllsands()
        {
            try
            {
                IEnumerable<Allsand> objList = _db.Allsand.ToList();
                _response.Result = (objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }




    }
}
