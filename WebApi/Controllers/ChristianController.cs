using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
   
    public class ChristianController : Controller
    {
        private readonly IChristian _christianService;
        public ChristianController(IChristian christianService)
        {
            _christianService = christianService;
        }
        public async Task<IActionResult> Index(int pg)
        {
            List<Christiansø>? list = new();

            ResponseDto? response = await _christianService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Christiansø>>(Convert.ToString(response.Result));
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
            List<Christiansø>? list = new List<Christiansø>();

            try
            {
                ResponseDto? response = await _christianService.GetAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Christiansø>>(Convert.ToString(response.Result)) ?? new List<Christiansø>();
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
            List<Christiansø> list = new List<Christiansø>();

            try
            {
                ResponseDto? response = await _christianService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var christian = JsonConvert.DeserializeObject<Christiansø>(Convert.ToString(response.Result));
                    if (christian != null)
                    {
                        list.Add(christian);
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
        public async Task<IActionResult> Create(Christiansø model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _christianService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = " En Christian-Sø created successfully";
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
            ResponseDto? response = await _christianService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Christiansø? model = JsonConvert.DeserializeObject<Christiansø>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Christiansø chris)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _christianService.UpdateAsync(chris);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "En Christian-Sø updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(chris);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _christianService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Christiansø? model = JsonConvert.DeserializeObject<Christiansø>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Christiansø chris)
        {
            ResponseDto? response = await _christianService.DeleteAsync(chris.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "En Christian-Sø deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(chris);
        }
    }
}
