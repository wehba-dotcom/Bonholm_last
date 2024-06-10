using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
   
    public class FtController : Controller
    {
        private readonly IFt _ftService;
        public FtController(IFt ftService)
        {
            _ftService = ftService;
        }
        public async Task<IActionResult> Index(int pg)
        {
            List<FT>? list = new();

            ResponseDto? response = await _ftService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<FT>>(Convert.ToString(response.Result));
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


        public async Task<IActionResult> Search(string? Fornavne)
        {
            List<FT>? list = new List<FT>();

            try
            {
                ResponseDto? response = await _ftService.GetByNameAsync(Fornavne);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<FT>>(Convert.ToString(response.Result)) ?? new List<FT>();
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
            List<FT> list = new List<FT>();

            try
            {
                ResponseDto? response = await _ftService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var ft = JsonConvert.DeserializeObject<FT>(Convert.ToString(response.Result));
                    if (ft != null)
                    {
                        list.Add(ft);
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
        public async Task<IActionResult> Create(FT model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ftService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "En FT1845 blev oprettet";
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
            ResponseDto? response = await _ftService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                FT? model = JsonConvert.DeserializeObject<FT>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FT ft)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ftService.UpdateAsync(ft);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "En FT1845 blev opdatere ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(ft);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _ftService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                FT? model = JsonConvert.DeserializeObject<FT>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FT ft)
        {
            ResponseDto? response = await _ftService.DeleteAsync(ft.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "En FT1845 blev slettet";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(ft);
        }
    }
}
