using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.IService;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
   
    public class FotoController : Controller
    {
        private readonly IFoto _fotoService;
        public FotoController(IFoto fotoService)
        {
            _fotoService = fotoService;
        }
        public async Task<IActionResult> Index(int pg)
        {
            List<Foto>? list = new();

            ResponseDto? response = await _fotoService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Foto>>(Convert.ToString(response.Result));
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
            List<Foto>? list = new List<Foto>();

            try
            {
                ResponseDto? response = await _fotoService.GetByNameAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Foto>>(Convert.ToString(response.Result)) ?? new List<Foto>();
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
            List<Foto> list = new List<Foto>();

            try
            {
                ResponseDto? response = await _fotoService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var foto = JsonConvert.DeserializeObject<Foto>(Convert.ToString(response.Result));
                    if (foto != null)
                    {
                        list.Add(foto);
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
        public async Task<IActionResult> Create(Foto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _fotoService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "En Foto blev oprettet";
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
            ResponseDto? response = await _fotoService.GetByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Foto? model = JsonConvert.DeserializeObject<Foto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Foto foto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _fotoService.UpdateAsync(foto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "En Foto blev opdateret";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(foto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _fotoService.GetByIdAsync(id);

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
        public async Task<IActionResult> Delete(Foto foto)
        {
            ResponseDto? response = await _fotoService.DeleteAsync(foto.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "En Foto blev slettet";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(foto);
        }
    }
}
