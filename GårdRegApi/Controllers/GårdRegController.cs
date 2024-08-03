using GårdRegApi.Data;
using GårdRegApi.Models;
using GårdRegApi.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GårdsRegApi.Controllers
{
    [Route("api/gårdreg")]
    [ApiController]
    [Authorize]
    public class GårdRegController : Controller
    {
        private readonly DbAppContext _db;
        private ResponseDto _response;
   
        public GårdRegController(DbAppContext db)
        {
            _db = db;

            _response = new ResponseDto();

        }

        // GET: api/gårdreg
        [HttpGet]
        public ResponseDto GetAll(string? Fornavne, string? Efternavn, string? ÆgtefællesFornavne, string? ÆgtefællesEfternavn)
        {
            try
            {
                IEnumerable<GårdReg> objList = _db.GårdRegistreringer.ToList();

                if (!String.IsNullOrEmpty(Fornavne))
                {
                    objList = objList.Where(b => b.Fornavne == Fornavne);
                }

                if (!String.IsNullOrEmpty(Efternavn))
                {
                    objList = objList.Where(b => b.Efternavn == Efternavn);
                }

                

                if (!String.IsNullOrEmpty(ÆgtefællesFornavne))
                {
                    objList = objList.Where(b => b.ÆgtefællesFornavne == ÆgtefællesFornavne);
                }

                if (!String.IsNullOrEmpty(ÆgtefællesEfternavn))
                {
                    objList = objList.Where(b => b.ÆgtefællesEfternavn == ÆgtefællesEfternavn);
                }

              

                _response.Result = objList;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }



        [HttpGet("search/{Fornavne}")]

        public ResponseDto Search(string? Fornavne)
        {
            var objList = from b in _db.GårdRegistreringer select b;

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
               GårdReg obj = _db.GårdRegistreringer.First(u => u.ID == ID);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        // POST::api/gårdreg
        [HttpPost]
        public ResponseDto Create([FromBody] GårdReg ft)
        {
            try
            {

                _db.GårdRegistreringer.Add(ft);
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

        // PUT: api/gårdreg/5
        [HttpPut]
         public ResponseDto Put(GårdReg ft)
        {
            try
            {
                GårdReg obj = ft;
                _db.GårdRegistreringer.Update(obj);
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
                GårdReg obj = _db.GårdRegistreringer.First(u => u.ID == ID);

                _db.GårdRegistreringer.Remove(obj);
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
            return _db.GårdRegistreringer.Any(e => e.ID == ID);
        }
    }
}
