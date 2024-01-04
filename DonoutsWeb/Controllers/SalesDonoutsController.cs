using DonoutsWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using DonoutsWeb.Interfaces;
using Donouts.Application.Dto.Donouts;
using NuGet.Common;
using System.Net.Http;
using Donouts.Application.Donnouts.Sales.Commands.Create;
using Donouts.Domain.Common;

namespace DonoutsWeb.Controllers
{
    public class SalesDonoutsController : Controller
    {
        private string apiUrl = "https://localhost:7157/api/v1/";
        private readonly HttpClient _httpClient;
        private readonly ISingletonService _singletonService;
        public SalesDonoutsController(ISingletonService singletonService)
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri(apiUrl);
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this._singletonService = singletonService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromForm] int amount, [FromForm] Guid typeDonoutsId)
        {
            try
            {
                
                var model = new CreateSalesDonoutsCommand();
                model.Amount = amount;
                model.TypeDonoutsId = typeDonoutsId;
                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _singletonService.Property);
                var response = await _httpClient.PostAsync("SalesDonouts/Save", content);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { Result = "Ok", Message = "guardado con éxito" });
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return BadRequest(responseContent);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, responseContent);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }
    }
}
