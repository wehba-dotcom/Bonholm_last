using BorgerskabApi.Data;
using BorgerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BorgerskabApi.Controllers
{
    [Route("api/borger")]
    [ApiController]
    [Authorize]
    public class BorgerController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        //private IMapper _mapper;
        public BorgerController(AppDbContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }

        // GET: api/borger
        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Borger> objList = _db.Borgerskab_Rønne_1701_66.ToList();
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
            var objList = from b in _db.Borgerskab_Rønne_1701_66 select b;

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
                Borger obj = _db.Borgerskab_Rønne_1701_66.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/borger
        [HttpPost]
        public ResponseDto Create([FromBody] Borger borger)
        {
            try
            {

                _db.Borgerskab_Rønne_1701_66.Add(borger);
                _db.SaveChanges();
                _response.Result = borger;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/borger/5
        [HttpPut]
        public ResponseDto Put(Borger borger)
        {
            try
            {
                Borger obj = borger;
                _db.Borgerskab_Rønne_1701_66.Update(obj);
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

        // DELETE: ap/borger/5
        [HttpDelete("{ID}")]
        public ResponseDto Delete(int? ID)
        {
            try
            {
                Borger obj = _db.Borgerskab_Rønne_1701_66.First(u => u.ID == ID);

                _db.Borgerskab_Rønne_1701_66.Remove(obj);
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
            return _db.Borgerskab_Rønne_1701_66.Any(e => e.ID == ID);
        }
    }
}
