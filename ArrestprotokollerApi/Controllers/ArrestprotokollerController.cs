using ArrestprotokollerApi.Data;
using ArrestprotokollerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArrestprotokollerApi.Controllers
{
    [Route("api/arrestprotokoller")]
    [ApiController]
    [Authorize]

    public class ArrestprotokollerController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        //private IMapper _mapper;
        public ArrestprotokollerController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }



        // GET: api/Arrestprotokoller
        [HttpGet]
        public ResponseDto GetAllArrestprotokollers()
        {
            try
            {
                IEnumerable<Arrestprotokoller> objList = _db.Arrestprotokoller.ToList();
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
            var objList = from b in _db.Arrestprotokoller select b;

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
        public ResponseDto GetAllsand(int ID)
        {
            try
            {
                Arrestprotokoller obj = _db.Arrestprotokoller.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/arrestprotokoller
        [HttpPost]
        public ResponseDto Create([FromBody] Arrestprotokoller arrestprotokoller)
        {
            try
            {

                _db.Arrestprotokoller.Add(arrestprotokoller);
                _db.SaveChanges();
                _response.Result = arrestprotokoller;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/arrestprotokoller/5
        [HttpPut]
        public ResponseDto Put(Arrestprotokoller arrestprotokoller)
        {
            try
            {
                Arrestprotokoller obj = arrestprotokoller;
                _db.Arrestprotokoller.Update(obj);
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

        // DELETE: ap/arrestprotokoller/5
        [HttpDelete("{ID}")]
        public ResponseDto DeleteArrestprotokoller(int? ID)
        {
            try
            {
                Arrestprotokoller obj = _db.Arrestprotokoller.First(u => u.ID == ID);

                _db.Arrestprotokoller.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        private bool ArrestprotokollerExists(int ID)
        {
            return _db.Arrestprotokoller.Any(e => e.ID == ID);
        }

    }
}
