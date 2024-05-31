using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
   
    public class BornController : Controller
    {
        private readonly IBørn _bornService;
        public BornController(IBørn bornService)
        {
            _bornService = bornService;
        }
        public async Task<IActionResult> Index(int pg)
        {
            List<Børn>? list = new();

            ResponseDto? response = await _bornService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Børn>>(Convert.ToString(response.Result));
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
            List<Børn>? list = new List<Børn>();

            try
            {
                ResponseDto? response = await _bornService.GetByNameAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Børn>>(Convert.ToString(response.Result)) ?? new List<Børn>();
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
            List<Børn> list = new List<Børn>();

            try
            {
                ResponseDto? response = await _bornService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var born = JsonConvert.DeserializeObject<Børn>(Convert.ToString(response.Result));
                    if (born != null)
                    {
                        list.Add(born);
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
        public async Task<IActionResult> Create(Børn model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bornService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Børn-Rø created successfully";
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
            ResponseDto? response = await _bornService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Børn? model = JsonConvert.DeserializeObject<Børn>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Børn børn)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bornService.UpdateAsync(børn);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Børn-Rø updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(børn);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _bornService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Børn? model = JsonConvert.DeserializeObject<Børn>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Børn born)
        {
            ResponseDto? response = await _bornService.DeleteAsync(born.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "BØrn-Rø deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(born);
        }
    }
}
