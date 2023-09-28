using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using DonoutsWeb.Interfaces;
using DonoutsWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace DonoutsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string apiUrl = "https://localhost:7293/api/v1/";
        private readonly ISingletonService _singletonService;
        public HomeController(ILogger<HomeController> logger, ISingletonService singletonService)
        {
           this._logger = logger;
            this._singletonService = singletonService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Privacy(String Id)
        {
            var confi = new Configuracion();
            using (HttpClient client = new HttpClient())
            {
                var method = string.Empty;
                if (string.IsNullOrEmpty(Id))
                {
                    method = "GetAll";
                }
                else
                {
                    method = "GetAllQuery?Id=" + Id;
                }
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"SalesDonouts/{method}");
                if (response.IsSuccessStatusCode)
                {
                    string dataRead = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ResponseDto<List<SalesDonoutsDTO>>>(dataRead);
                    confi.salesDonouts = data!.Data;
                    return View(confi);
                }
                else
                {
                    return BadRequest(confi);
                }
            }
        }
        

        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var select = new List<SelectListItem>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "TypeDonouts/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    string dataRead = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ResponseDto<List<TypeDonoutsDTO>>>(dataRead);
                    foreach (var item in data.Data)
                    {
                        select.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    }
                    return Json(new { Result = "Ok", Data = select });
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}