using FotoApi.Data;
using FotoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FotoApi.Controllers
{
    [Route("api/foto")]
    [ApiController]
    [Authorize]
    public class FotoController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
   
        public FotoController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }

        // GET: api/foto
        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Foto> objList = _db.Foto.ToList();
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
            var objList = from b in _db.Foto select b;

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
                Foto obj = _db.Foto.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/foto
        [HttpPost]
        public ResponseDto Create([FromBody] Foto foto)
        {
            try
            {

                _db.Foto.Add(foto);
                _db.SaveChanges();
                _response.Result = foto;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/foto/5
        [HttpPut]
        public ResponseDto Put(Foto foto)
        {
            try
            {
                Foto obj = foto;
                _db.Foto.Update(obj);
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

        // DELETE: ap/foto/5
        [HttpDelete("{ID}")]
        public ResponseDto Delete(int? ID)
        {
            try
            {
                Foto obj = _db.Foto.First(u => u.ID == ID);

                _db.Foto.Remove(obj);
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
            return _db.Foto.Any(e => e.ID == ID);
        }
    }
}
