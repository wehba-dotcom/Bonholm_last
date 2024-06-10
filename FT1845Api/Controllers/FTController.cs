using FT1845Api.Data;
using FT1845Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT1845Api.Controllers
{
    [Route("api/ft")]
    [ApiController]
    //[Authorize]
    public class FTController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
   
        public FTController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }

        // GET: api/ft
        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<FT> objList = _db.FT1845.ToList();
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

        public ResponseDto Search(string? Fornavne)
        {
            var objList = from b in _db.FT1845 select b;

            try
            {
                if (!String.IsNullOrEmpty(Fornavne))
                {
                    objList = objList.Where(b => b.Fornavne == Fornavne);
                    _response.Result = objList;
                }
                else if (String.IsNullOrEmpty(Fornavne))
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
                FT obj = _db.FT1845.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/ft
        [HttpPost]
        public ResponseDto Create([FromBody] FT ft)
        {
            try
            {

                _db.FT1845.Add(ft);
                _db.SaveChanges();
                _response.Result = ft;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/ft/5
        [HttpPut]
        public ResponseDto Put(FT ft)
        {
            try
            {
                FT obj = ft;
                _db.FT1845.Update(obj);
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

        // DELETE: ap/ft/5
        [HttpDelete("{ID}")]
        public ResponseDto Delete(int? ID)
        {
            try
            {
                FT obj = _db.FT1845.First(u => u.ID == ID);

                _db.FT1845.Remove(obj);
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
            return _db.FT1845.Any(e => e.ID == ID);
        }
    }
}
