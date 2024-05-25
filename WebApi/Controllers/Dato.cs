using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Models;
using WebApi.Service.IService;
using WebApi.Service;

namespace WebApi.Controllers
{
    public class DatoController : Controller
    {
        private readonly IDato1822 _datoService;
        public DatoController(IDato1822 datoService)
        {
            _datoService = datoService;
        }


        public async Task<IActionResult> Index(int pg)
        {
            List<Dato1822>? list = new();

            ResponseDto? response = await _datoService.GetAllDatosAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Dato1822>>(Convert.ToString(response.Result));
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
            List<Dato1822>? list = new List<Dato1822>();

            try
            {
                ResponseDto? response = await _datoService.GetDatoByNameAsync(Fornavn);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Dato1822>>(Convert.ToString(response.Result)) ?? new List<Dato1822>();
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
            List<Dato1822> list = new List<Dato1822>();

            try
            {
                ResponseDto? response = await _datoService.GetDatoByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var allsand = JsonConvert.DeserializeObject<Dato1822>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> Create(Dato1822 model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _datoService.CreateDatoAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Dato1822 created successfully";
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
            ResponseDto? response = await _datoService.GetDatoByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Dato1822? model = JsonConvert.DeserializeObject<Dato1822>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dato1822 dato)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _datoService.UpdateDatoAsync(dato);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Dato1822 updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(dato);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _datoService.GetDatoByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                Dato1822? model = JsonConvert.DeserializeObject<Dato1822>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Dato1822 dato)
        {
            ResponseDto? response = await _datoService.DeleteDatoAsync(dato.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Dato1822 deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(dato);
        }
    }
}
