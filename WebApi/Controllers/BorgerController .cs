using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
   
    public class BorgerController : Controller
    {
        private readonly IBorger _borgerService;
        public BorgerController(IBorger borgerService)
        {
            _borgerService = borgerService;
        }
        public async Task<IActionResult> Index(int pg)
        {
            List<Borger>? list = new();

            ResponseDto? response = await _borgerService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Borger>>(Convert.ToString(response.Result));
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
            List<Borger>? list = new List<Borger>();

            try
            {
                ResponseDto? response = await _borgerService.GetByNameAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Borger>>(Convert.ToString(response.Result)) ?? new List<Borger>();
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
            List<Borger> list = new List<Borger>();

            try
            {
                ResponseDto? response = await _borgerService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var borger = JsonConvert.DeserializeObject<Borger>(Convert.ToString(response.Result));
                    if (borger != null)
                    {
                        list.Add(borger);
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
        public async Task<IActionResult> Create(Borger model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _borgerService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Borgerskab created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            ResponseDto? response = await _borgerService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Borger? model = JsonConvert.DeserializeObject<Borger>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Borger borger)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _borgerService.UpdateAsync(borger);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Borgerskab updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(borger);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _borgerService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Borger? model = JsonConvert.DeserializeObject<Borger>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete( Borger borger)
        {
            ResponseDto? response = await _borgerService.DeleteAsync(borger.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Borgerskab deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(borger);
        }
    }
}
