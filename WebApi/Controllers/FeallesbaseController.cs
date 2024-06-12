
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Models;
using System.Reflection;


namespace WebApi.Controllers
{



    public class FeallesbaseController : Controller
    {
        private readonly IFeallesService _feallesService;
        public FeallesbaseController(IFeallesService feallesService)
        {
            _feallesService = feallesService;
        }


        public async Task<IActionResult> Index(int pg, string? Fornavne, string? Efternavn, string? Doebenavn, DateTime? Doedsdato, string? Begravelsessted, string? Efterladte)
        {
            List<Feallesbase>? list = new();

            ResponseDto? response = await _feallesService.GetAllFeallesesAsync( Fornavne, Efternavn,  Doebenavn, Doedsdato, Begravelsessted, Efterladte);

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Feallesbase>>(Convert.ToString(response.Result));
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
            var data = list.Skip(resSkip).Take(pager.PageSize).ToList();

            //var data = objLists.ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        public async Task<IActionResult> Search(string? fornavne, string? efternavn, string? doebenavn, DateTime? doedsdato, string? begravelsessted, string? efterladte)
        {
            List<Feallesbase>? list = new List<Feallesbase>();

            try
            {
                ResponseDto? response = await _feallesService.Search( fornavne,  efternavn,doebenavn, doedsdato, begravelsessted, efterladte);

                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Feallesbase>>(Convert.ToString(response.Result)) ?? new List<Feallesbase>();
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
        public async Task<IActionResult> Create(Feallesbase model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _feallesService.CreateFeallesAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Feallesbase created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }



        public async Task<IActionResult> Getbyid(int ID)
        {
            List<Feallesbase> list = new List<Feallesbase>();

            try
            {
                ResponseDto? response = await _feallesService.GetFeallesByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var feallesbase = JsonConvert.DeserializeObject<Feallesbase>(Convert.ToString(response.Result));
                    if (feallesbase != null)
                    {
                        list.Add(feallesbase);
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




        public async Task<IActionResult> FeallesEdit(int ID)
        {
            ResponseDto? response = await _feallesService.GetFeallesByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                Feallesbase? model = JsonConvert.DeserializeObject<Feallesbase>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> FeallesEdit(Feallesbase feallesbase)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _feallesService.UpdateFeallesAsync(feallesbase);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "FeallesBase updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(feallesbase);
        }

        public async Task<IActionResult> Delete(int ID)
        {
            ResponseDto? response = await _feallesService.GetFeallesByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                Feallesbase? model = JsonConvert.DeserializeObject<Feallesbase>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Feallesbase feallesbase)
        {
            ResponseDto? response = await _feallesService.DeleteFeallesAsync(feallesbase.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "FeallesBase deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(feallesbase);
        }


    }

}

