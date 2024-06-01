using ChristiansøApi.Data;
using ChristiansøApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChristiansøApi.Controllers
{
    [Route("api/christian")]
    [ApiController]
    [Authorize]
    public class ChristiansøController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
   
        public ChristiansøController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }

        // GET: api/christian
        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Christiansø> objList = _db.Christiansø_personale.ToList();
                _response.Result = (objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }


        [HttpGet("search/{Fornavn}")]

        public ResponseDto Search(string? Fornavn)
        {
            var objList = from b in _db.Christiansø_personale select b;

            try
            {
                if (!String.IsNullOrEmpty(Fornavn))
                {
                    objList = objList.Where(b => b.Fornavn == Fornavn);
                    _response.Result = objList;
                }
                else if (String.IsNullOrEmpty(Fornavn))
                {
                    _response.Message = _response?.Message ?? "An unknown error occurred.";
                }
            }
            catch (Exception ex)
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
                Christiansø obj = _db.Christiansø_personale.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/christian
        [HttpPost]
        public ResponseDto Create([FromBody] Christiansø christian)
        {
            try
            {

                _db.Christiansø_personale.Add(christian);
                _db.SaveChanges();
                _response.Result = christian;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/christain/5
        [HttpPut]
        public ResponseDto Put(Christiansø christian)
        {
            try
            {
                Christiansø obj = christian;
                _db.Christiansø_personale.Update(obj);
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

        // DELETE: ap/christian/5
        [HttpDelete("{ID}")]
        public ResponseDto Delete(int? ID)
        {
            try
            {
                Christiansø obj = _db.Christiansø_personale.First(u => u.ID == ID);

                _db.Christiansø_personale.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        private bool Exists(int ID)
        {
            return _db.Christiansø_personale.Any(e => e.ID == ID);
        }
    }
}
