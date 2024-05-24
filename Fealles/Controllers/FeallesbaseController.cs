﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeallesBaseApi.Models;
using FeallesBaseApi.Data;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Stripe;
using String = System.String;

namespace FeallesBaseApi.Controllers
{

    
    [Route("api/feallesbase")]
    [ApiController]
    [Authorize]
    public class FeallesbaseController : ControllerBase

    {


        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public FeallesbaseController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();

        }

        // GET: api/Feallesbase
        [HttpGet]
        public  ResponseDto GetFeallesbases()
        {

            try
            {
                IEnumerable<Feallesbase> objList = _db.Feallesbases.ToList();
                _response.Result = (objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }


        [HttpGet("search/{Fornavne}")]
        
        public ResponseDto Search( string? Fornavne)
        {
            var objList = from b in _db.Feallesbases select b;

            try
            {
                if (!String.IsNullOrEmpty(Fornavne))
                {
                    objList = objList.Where(b => b.Fornavne == Fornavne);
                    _response.Result = objList;
                }else if(String.IsNullOrEmpty(Fornavne))
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






        // GET: api/Feallesbase/5
        [HttpGet("{ID:int}")]
        public ResponseDto GetFeallesbase(int ID)
        {
            try
            {
                Feallesbase obj = _db.Feallesbases.First(u => u.ID== ID);
                _response.Result = _mapper.Map<Feallesbase>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // POST: api/Feallesbase
        [HttpPost]
        public ResponseDto Create([FromBody] Feallesbase feallesbase)
        {
            try
            {
                Feallesbase obj = _mapper.Map<Feallesbase>(feallesbase);
                _db.Feallesbases.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<Feallesbase>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }
        // PUT: api/Feallesbase/5
        [HttpPut]
        public ResponseDto Put(  Feallesbase feallesbase)
        {
            try
            {
                Feallesbase obj = _mapper.Map<Feallesbase>(feallesbase);
                _db.Feallesbases.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<Feallesbase>(obj);
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
        public ResponseDto DeleteFeallesbase(int? ID)
        {
            try
            {
                Feallesbase obj = _db.Feallesbases.First(u => u.ID == ID);
               
                _db.Feallesbases.Remove(obj);
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
            return _db.Feallesbases.Any(e => e.ID == ID);
        }

    }
}


