using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Models;
using WebApi.Service.IService;
using WebApi.Service;

namespace WebApi.Controllers
{
    public class AllsandController : Controller
    {
        private readonly IAllsand _allsandService;
        public AllsandController(IAllsand allsandService)
        {
            _allsandService = allsandService;
        }


        public async Task<IActionResult> Index(int pg)
        {
            List<Allsand>? list = new();

            ResponseDto? response = await _allsandService.GetAllAsandssAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Allsand>>(Convert.ToString(response.Result));
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
            List<Allsand>? list = new List<Allsand>();

            try
            {
                ResponseDto? response = await _allsandService.GetAllsandAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Allsand>>(Convert.ToString(response.Result)) ?? new List<Allsand>();
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
            List<Allsand> list = new List<Allsand>();

            try
            {
                ResponseDto? response = await _allsandService.GetAllsandByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var allsand = JsonConvert.DeserializeObject<Allsand>(Convert.ToString(response.Result));
                    if (allsand != null)
                    {
                        list.Add(allsand);
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
        public async Task<IActionResult> Create(Allsand model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _allsandService.CreateAllsandAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Allsand created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        public async Task<IActionResult> AllsandEdit(int id)
        {
            ResponseDto? response = await _allsandService.GetAllsandByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Allsand? model = JsonConvert.DeserializeObject<Allsand>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AllsandEdit(Allsand allsand)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _allsandService.UpdateAllsandAsync(allsand);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Allsand updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(allsand);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _allsandService.GetAllsandByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Allsand? model = JsonConvert.DeserializeObject<Allsand>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Allsand allsand)
        {
            ResponseDto? response = await _allsandService.DeleteAllsandAsync(allsand.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Allsand deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(allsand);
        }
    }
}
