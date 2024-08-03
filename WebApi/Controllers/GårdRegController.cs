
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Models;
using System.Reflection;


namespace WebApi.Controllers
{



    public class GårdRegController : Controller
    {
        private readonly IGårdReg _gårdregService;
        public GårdRegController(IGårdReg gårdregService)
        {
            _gårdregService = gårdregService;
        }


        public async Task<IActionResult> Index(int pg, string? Fornavne, string? Efternavn, string? ÆgtefællesFornavne, string? ÆgtefællesEfternavn) { 
            List<GårdReg>? list = new();

            ResponseDto? response = await _gårdregService.GetAllAsync( Fornavne, Efternavn, ÆgtefællesFornavne, ÆgtefællesEfternavn);

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<GårdReg>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }


            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = list.Count();
            var pager = new WebApi.Models.Pager(recsCount, pg, pageSize);
            int resSkip = (pg - 1) * pageSize;
            var data = list.Skip(resSkip).Take(pager.PageSize).ToList();

            //var data = objLists.ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

       

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GårdReg model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _gårdregService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = " Gård Registrere oprettet med succes";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }



        public async Task<IActionResult> Getbyid(int ID)
        {
            List<GårdReg> list = new List<GårdReg>();

            try
            {
                ResponseDto? response = await _gårdregService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var gårdreg = JsonConvert.DeserializeObject<GårdReg>(Convert.ToString(response.Result));
                    if (gårdreg != null)
                    {
                        list.Add(gårdreg);
                    }
                }
                else
                {
                    TempData["error"] = response?.Message ?? "An unknown error occurred.";
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to use a logging framework for this)
                TempData["error"] = $"An error occurred while searching: {ex.Message}";
            }

            return View(list);
        }




        public async Task<IActionResult> Edit(int ID)
        {
            ResponseDto? response = await _gårdregService.GetByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                GårdReg? model = JsonConvert.DeserializeObject<GårdReg>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GårdReg gårdreg)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _gårdregService.UpdateAsync(gårdreg);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "GårdRegestrere  opdateret med succes";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(gårdreg);
        }

        public async Task<IActionResult> Delete(int ID)
        {
            ResponseDto? response = await _gårdregService.GetByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                GårdReg? model = JsonConvert.DeserializeObject<GårdReg>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GårdReg gårdreg)
        {
            ResponseDto? response = await _gårdregService.DeleteAsync(gårdreg.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "GårdRegestrere  slettet med succes";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(gårdreg);
        }


    }

}

