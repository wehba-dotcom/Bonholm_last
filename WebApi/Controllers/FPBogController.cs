
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Models;
using System.Reflection;


namespace WebApi.Controllers
{



    public class FPBogController : Controller
    {
        private readonly IFPBog _fpbogService;
        public FPBogController(IFPBog fpbogService)
        {
            _fpbogService = fpbogService;
        }


        public async Task<IActionResult> Index(int pg, string? Fornavn, string? Efternavn, string? ForrigeFaesterFornavn, string? ForrigeFaesterEfternavn, string? Gaard, string? Sogn)
        {
            List<FPBog>? list = new();

            ResponseDto? response = await _fpbogService.GetAllAsync( Fornavn, Efternavn, ForrigeFaesterFornavn, ForrigeFaesterEfternavn, Gaard, Sogn);

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<FPBog>>(Convert.ToString(response.Result));
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

        //public async Task<IActionResult> Search(string? fornavne, string? efternavn, string? doebenavn, DateTime? doedsdato, string? begravelsessted, string? efterladte)
        //{
        //    List<Feallesbase>? list = new List<Feallesbase>();

        //    try
        //    {
        //        ResponseDto? response = await _feallesService.Search( fornavne,  efternavn,doebenavn, doedsdato, begravelsessted, efterladte);

        //        if (response != null && response.IsSuccess)
        //        {
        //            list = JsonConvert.DeserializeObject<List<Feallesbase>>(Convert.ToString(response.Result)) ?? new List<Feallesbase>();
        //        }
        //        else
        //        {
        //            TempData["error"] = response?.Message ?? "An unknown error occurred.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (you might want to use a logging framework for this)
        //        TempData["error"] = $"An error occurred while searching: {ex.Message}";
        //    }

        //    return View(list);
        //}





        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FPBog model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _fpbogService.CreateAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Fæste protokoller bog created successfully";
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
            List<FPBog> list = new List<FPBog>();

            try
            {
                ResponseDto? response = await _fpbogService.GetByIdAsync(ID);

                if (response != null && response.IsSuccess)
                {
                    var fpbog = JsonConvert.DeserializeObject<FPBog>(Convert.ToString(response.Result));
                    if (fpbog != null)
                    {
                        list.Add(fpbog);
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




        public async Task<IActionResult> Edit(int ID)
        {
            ResponseDto? response = await _fpbogService.GetByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                FPBog? model = JsonConvert.DeserializeObject<FPBog>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FPBog fpbog)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _fpbogService.UpdateAsync(fpbog);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Fæste protokoller bog  updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(fpbog);
        }

        public async Task<IActionResult> Delete(int ID)
        {
            ResponseDto? response = await _fpbogService.GetByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                FPBog? model = JsonConvert.DeserializeObject<FPBog>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FPBog fpbog)
        {
            ResponseDto? response = await _fpbogService.DeleteAsync(fpbog.ID);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Fæste protokoller bog  deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(fpbog);
        }


    }

}

