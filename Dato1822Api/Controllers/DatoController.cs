using Dato1822Api.Data;
using Dato1822Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dato1822Api.Controllers
{
    [Route("api/dato")]
    [ApiController]
    [Authorize]
    public class DatoController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        //private IMapper _mapper;
        public DatoController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }



        // GET: api/dato
        [HttpGet]
        public ResponseDto GetAllDato()
        {
            try
            {
                IEnumerable<Dato1822> objList = _db.Dato1822.ToList();
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
            var objList = from b in _db.Dato1822 select b;

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
        public ResponseDto GetDato(int ID)
        {
            try
            {
                Dato1822 obj = _db.Dato1822.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/dato
        [HttpPost]
        public ResponseDto Create([FromBody] Dato1822 dato1822)
        {
            try
            {

                _db.Dato1822.Add(dato1822);
                _db.SaveChanges();
                _response.Result = dato1822;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/dato/5
        [HttpPut]
        public ResponseDto Put(Dato1822 dato1822)
        {
            try
            {
                Dato1822 obj = dato1822;
                _db.Dato1822.Update(obj);
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

        // DELETE: ap/dato/5
        [HttpDelete("{ID}")]
        public ResponseDto DeleteDato(int? ID)
        {
            try
            {
                Dato1822 obj = _db.Dato1822.First(u => u.ID == ID);

                _db.Dato1822.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        private bool DatoExists(int ID)
        {
            return _db.Dato1822.Any(e => e.ID == ID);
        }


    }
}
