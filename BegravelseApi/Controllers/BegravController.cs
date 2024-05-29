using BegravelseApi.Data;
using BegravelseApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BegravelseApi.Controllers
{
    [Route("api/begrav")]
    [ApiController]
    [Authorize]

    public class BegravController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        //private IMapper _mapper;
        public BegravController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }



        // GET: api/begrav
        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Begrav> objList = _db.Begravelseprotokoller.ToList();
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
            var objList = from b in _db.Begravelseprotokoller select b; 

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
                Begrav obj = _db.Begravelseprotokoller.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/begrav
        [HttpPost]
        public ResponseDto Create([FromBody] Begrav begrav)
        {
            try
            {

                _db.Begravelseprotokoller.Add(begrav);
                _db.SaveChanges();
                _response.Result = begrav;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/begrav/5
        [HttpPut]
        public ResponseDto Put(Begrav begrav)
        {
            try
            {
                Begrav obj = begrav;
                _db.Begravelseprotokoller.Update(obj);
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

        // DELETE: ap/begrav/5
        [HttpDelete("{ID}")]
        public ResponseDto Delete(int? ID)
        {
            try
            {
                Begrav obj = _db.Begravelseprotokoller.First(u => u.ID == ID);

                _db.Begravelseprotokoller.Remove(obj);
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
            return _db.Begravelseprotokoller.Any(e => e.ID == ID);
        }

    }
}
