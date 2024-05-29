using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
   
    public class BegravController : Controller
    {
        private readonly IBegrav _begravService;
        public BegravController(IBegrav begravService)
        {
            _begravService = begravService;
        }
        public async Task<IActionResult> Index(int pg)
        {
            List<Begrav>? list = new();

            ResponseDto? response = await _begravService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Begrav>>(Convert.ToString(response.Result));
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
            List<Begrav>? list = new List<Begrav>();

            try
            {
                ResponseDto? response = await _begravService.GetByNameAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Begrav>>(Convert.ToString(response.Result)) ?? new List<Begrav>();
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
            List<Begrav> list = new List<Begrav>();

            try
            {
                ResponseDto? response = await _begravService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var begrav = JsonConvert.DeserializeObject<Begrav>(Convert.ToString(response.Result));
                    if (begrav != null)
                    {
                        list.Add(begrav);
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
        public async Task<IActionResult> Create(Begrav model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _begravService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Begravelse created successfully";
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
            ResponseDto? response = await _begravService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Begrav? model = JsonConvert.DeserializeObject<Begrav>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Begrav begrav)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _begravService.UpdateAsync(begrav);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Begravelse updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(begrav);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _begravService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Begrav? model = JsonConvert.DeserializeObject<Begrav>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Begrav begrav)
        {
            ResponseDto? response = await _begravService.DeleteAsync(begrav.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "begravelse Protokoller deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(begrav);
        }
    }
}
