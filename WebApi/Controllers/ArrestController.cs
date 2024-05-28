using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
    public class ArrestController : Controller
    {
        private readonly IArrestprotokol _ArrestService;
        public ArrestController(IArrestprotokol arrestService)
        {
            _ArrestService = arrestService;
        }


        public async Task<IActionResult> Index(int pg)
        {
            List<Arrestprotokoller>? list = new();

            ResponseDto? response = await _ArrestService.GetAllArrestprotokolsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Arrestprotokoller>>(Convert.ToString(response.Result));
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
            List<Arrestprotokoller>? list = new List<Arrestprotokoller>();

            try
            {
                ResponseDto? response = await _ArrestService.GetArrestprotokolByNameAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Arrestprotokoller>>(Convert.ToString(response.Result)) ?? new List<Arrestprotokoller>();
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
            List<Arrestprotokoller> list = new List<Arrestprotokoller>();

            try
            {
                ResponseDto? response = await _ArrestService.GetArrestprotokolByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var arrestprotokoller = JsonConvert.DeserializeObject<Arrestprotokoller>(Convert.ToString(response.Result));
                    if (arrestprotokoller != null)
                    {
                        list.Add(arrestprotokoller);
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
        public async Task<IActionResult> Create(Arrestprotokoller model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ArrestService.CreateArrestprotokolAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "ArrestProtokoller created successfully";
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
            ResponseDto? response = await _ArrestService.GetArrestprotokolByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Arrestprotokoller? model = JsonConvert.DeserializeObject<Arrestprotokoller>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Arrestprotokoller arrest)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ArrestService.UpdateArrestprotokolAsync(arrest);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "ArrestProtokoller updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(arrest);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _ArrestService.GetArrestprotokolByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Arrestprotokoller? model = JsonConvert.DeserializeObject<Arrestprotokoller>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Arrestprotokoller arrest)
        {
            ResponseDto? response = await _ArrestService.DeleteArrestprotokolAsync(arrest.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "ArrestProtokoller deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(arrest);
        }

    }
}