
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Models;
using WebApi.Service;


namespace WebApi.Controllers
{



    public class AfgangTilgangController : Controller
    {
        private readonly IAfgangTilgangService _afgangTilgangService;
        public AfgangTilgangController(IAfgangTilgangService afgangTilgangService)
        {
            _afgangTilgangService = afgangTilgangService;
        }


        public async Task<IActionResult> Index(int pg)
        {
            List<AfgangTilgang>? list = new();

            ResponseDto? response = await _afgangTilgangService.GetAllAfgangsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AfgangTilgang>>(Convert.ToString(response.Result));
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
            var data = list.Skip(resSkip).Take(pager.PageSize);

            //var data = objLists.ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }


        public async Task<IActionResult> Search(string? Fornavn)
        {
            List<AfgangTilgang>? list = new List<AfgangTilgang>();

            try
            {
                ResponseDto? response = await _afgangTilgangService.GetAfgansAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<AfgangTilgang>>(Convert.ToString(response.Result)) ?? new List<AfgangTilgang>();
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



        public async Task<IActionResult> Getbyid(int ID)
        {
            List<AfgangTilgang> list = new List<AfgangTilgang>();

            try
            {
                ResponseDto? response = await _afgangTilgangService.GetAfgangsByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var afgangtilgang = JsonConvert.DeserializeObject<AfgangTilgang>(Convert.ToString(response.Result));
                    if (afgangtilgang != null)
                    {
                        list.Add(afgangtilgang);
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(AfgangTilgang model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _afgangTilgangService.CreateAfgangsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "AfgangTilgang created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        public async Task<IActionResult> AfgangsEdit(int id)
        {
            ResponseDto? response = await _afgangTilgangService.GetAfgangsByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                AfgangTilgang? model = JsonConvert.DeserializeObject<AfgangTilgang>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AfgangsEdit(AfgangTilgang afgangTilgang)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _afgangTilgangService.UpdateAfgangsAsync(afgangTilgang);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "AfgangTilgang updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(afgangTilgang);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _afgangTilgangService.GetAfgangsByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                AfgangTilgang? model = JsonConvert.DeserializeObject<AfgangTilgang>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AfgangTilgang afgangTilgang)
        {
            ResponseDto? response = await _afgangTilgangService.DeleteAfgangsAsync(afgangTilgang.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "FeallesBase deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(afgangTilgang);
        }


    }

}

