using FæsteProtokollerBog.Data;
using FæsteProtokollerBog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FæsteProtokollerBog.Controllers
{
    [Route("api/FPBog")]
    [ApiController]
    [Authorize]
    public class FPBogController: Controller
    {
      
        private readonly DbContextApplication _db;
        private readonly ResponseDto _response;

        public FPBogController(DbContextApplication db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto GetAll(string? Fornavn, string? Efternavn, string? ForrigeFaesterFornavn, string? ForrigeFaesterEfternavn, string? Gaard, string? Sogn)
        {
            var boge = from b in _db.FæsteProtokollerBog select b;
            try
            {
                 if(!String.IsNullOrEmpty(Fornavn))
                {
                    boge = _db.FæsteProtokollerBog.Where(x => x.Fornavn == Fornavn);
                }
                 if(!String.IsNullOrEmpty(Efternavn))
                {
                    boge = _db.FæsteProtokollerBog.Where(x => x.Efternavn == Efternavn);
                }
                 if(!String.IsNullOrEmpty(ForrigeFaesterFornavn))
                {
                    boge = _db.FæsteProtokollerBog.Where(x => x.ForrigeFaesterFornavn == ForrigeFaesterFornavn);
                }
                 if(!String.IsNullOrEmpty(ForrigeFaesterEfternavn))
                {
                    boge = _db.FæsteProtokollerBog.Where(x => x.ForrigeFaesterEfternavn == ForrigeFaesterEfternavn);
                }
                 if(!String.IsNullOrEmpty(Gaard))
                {
                    boge = _db.FæsteProtokollerBog.Where(x=> x.Gaard == Gaard);
                }
                 if (!String.IsNullOrEmpty(Gaard))
                {
                    boge = _db.FæsteProtokollerBog.Where(x => x.Sogn == Sogn);
                }
                _response.Result = boge.ToList();
                _response.IsSuccess = true;

            }catch (Exception ex)
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
                FPBog? obj = _db.FæsteProtokollerBog.First(x=> x.ID==ID);
                _response.Result = obj;

            }catch(Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        // POST: api/FPBog
        [HttpPost]
        public ResponseDto Create([FromBody] FPBog fpbog)
        {
            try
            {
               
                _db.FæsteProtokollerBog.Add(fpbog);
                _db.SaveChanges();
                _response.Result = fpbog;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }
        // PUT: api/FPBog/5
        [HttpPut]
        public ResponseDto Put(FPBog fpbog)
        {
            try
            {
                
                _db.FæsteProtokollerBog.Update(fpbog);
                _db.SaveChanges();

                _response.Result = fpbog;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // DELETE: api/FPBog/5
        [HttpDelete("{ID}")]
        public ResponseDto DeleteFeallesbase(int? ID)
        {
            try
            {
                FPBog obj = _db.FæsteProtokollerBog.First(u => u.ID == ID);

                _db.FæsteProtokollerBog.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        private bool FeallesbaseExists(int ID)
        {
            return _db.FæsteProtokollerBog.Any(e => e.ID == ID);
        }


    }
}
