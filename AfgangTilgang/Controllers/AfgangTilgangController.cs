using AfgangTilgangApi.Data;
using AfgangTilgangApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AfgangTilgangApi.Controllers
{

    [Route("api/afgangtilgang")]
    [ApiController]
    [Authorize]
    public class AfgangTilgangController : ControllerBase
    {

        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public AfgangTilgangController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();

        }
        // GET: api/Afgangtilgang
        [HttpGet]
        public ResponseDto GetAgangtilgangs()
        {
            try
            {
                IEnumerable<AfgangTilgang> objList = _db.AfgangTilgang.ToList();
                _response.Result = (objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }




        // GET: api/AfgangTilgang/5
        [HttpGet("{ID:int}")]
        public ResponseDto GetAfgangTilgang(int ID)
        {

           
            try
            {
                AfgangTilgang obj = _db.AfgangTilgang.First(u => u.ID == ID);
                _response.Result = _mapper.Map<AfgangTilgang>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        //Get :api/afgangtilgang/search/{Fornavn}
        [HttpGet("search/{Fornavn}")]
        public ResponseDto Search(string? Fornavn)
        {
            var objlist = from b in _db.AfgangTilgang select b;
            try
            {
                if(!String.IsNullOrEmpty(Fornavn))
                {
                    objlist = objlist.Where(b => b.Fornavn == Fornavn);
                    _response.Result = objlist;
                }
                else
                {
                    _response.Message = "No search criteria provided.";
                    _response.IsSuccess = false;
                }
               
            }catch(Exception ex)
            {
                _response.Message = ex.Message;
            }
            return _response;
        }






        // POST::api/AfgangTilgang
        [HttpPost]
        public ResponseDto Create([FromBody]AfgangTilgang afgangtilgang)
        {
            try
            {
               
                _db.AfgangTilgang.Add(afgangtilgang);
                _db.SaveChanges();
                _response.Result = afgangtilgang;

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        // PUT: api/Feallesbase/5
        [HttpPut]
        public ResponseDto Put(AfgangTilgang afgangTilgang)
        {
            try
            {
                AfgangTilgang obj = _mapper.Map<AfgangTilgang>(afgangTilgang);
                _db.AfgangTilgang.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<AfgangTilgang>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // DELETE: api/Feallesbase/5
        [HttpDelete("{ID}")]
        public ResponseDto DeleteAgangtilgang(int? ID)
        {
            try
            {
                AfgangTilgang obj = _db.AfgangTilgang.First(u => u.ID == ID);

                _db.AfgangTilgang.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        private bool AfgangTilgangExists(int ID)
        {
            return _db.AfgangTilgang.Any(e => e.ID == ID);
        }
    }
}
