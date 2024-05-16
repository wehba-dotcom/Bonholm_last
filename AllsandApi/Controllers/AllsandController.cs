using AllsandApi.Data;
using AllsandApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllsandApi.Controllers
{
    [Route("api/allsand")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{id}")]
        public ResponseDto GetAllsand(int id)
        {
            try
            {
                Allsand obj = _db.Allsand.First(u => u.ID == id);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/Allsand
        [HttpPost]
        public ResponseDto Create([FromBody] Allsand allsand)
        {
            try
            {

                _db.Allsand.Add(allsand);
                _db.SaveChanges();
                _response.Result = allsand;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/allsand/5
        [HttpPut]
        public ResponseDto Put(Allsand allsand)
        {
            try
            {
                Allsand obj = allsand;
                _db.Allsand.Update(obj);
                _db.SaveChanges();

                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // DELETE: ap/allsand/5
        [HttpDelete("{ID}")]
        public ResponseDto DeleteAllsand(int? ID)
        {
            try
            {
                Allsand obj = _db.Allsand.First(u => u.ID == ID);

                _db.Allsand.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        private bool AllsandExists(int ID)
        {
            return _db.Allsand.Any(e => e.ID == ID);
        }



    }
}
