using BørnRøApi.Data;
using BørnRøApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BørnRøApi.Controllers
{
    [Route("api/born")]
    [ApiController]
    [Authorize]
    public class BørnController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
   
        public BørnController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }

        // GET: api/born
        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Børn> objList = _db.Børn_Rø_1737.ToList();
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
            var objList = from b in _db.Børn_Rø_1737 select b;

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
                Børn obj = _db.Børn_Rø_1737.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/born
        [HttpPost]
        public ResponseDto Create([FromBody] Børn børn)
        {
            try
            {

                _db.Børn_Rø_1737.Add(børn);
                _db.SaveChanges();
                _response.Result = børn;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/born/5
        [HttpPut]
        public ResponseDto Put(Børn børn)
        {
            try
            {
                Børn obj = børn;
                _db.Børn_Rø_1737.Update(obj);
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

        // DELETE: ap/born/5
        [HttpDelete("{ID}")]
        public ResponseDto Delete(int? ID)
        {
            try
            {
                Børn obj = _db.Børn_Rø_1737.First(u => u.ID == ID);

                _db.Børn_Rø_1737.Remove(obj);
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
            return _db.Børn_Rø_1737.Any(e => e.ID == ID);
        }
    }
}
