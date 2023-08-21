using DonoutsWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using DonoutsWeb.Interfaces;

namespace DonoutsWeb.Controllers
{
    public class LoginController : Controller
    {
        private string apiUrl = "https://localhost:7293/api/v1/";
        private readonly HttpClient _httpClient;
        private readonly ISingletonService _singletonService;
        public LoginController(ISingletonService singletonService)
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri(apiUrl);
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this._singletonService = singletonService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jsonModel = JsonConvert.SerializeObject(model);
                    var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("Authentication/login", content);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string jwtToken = responseContent.Replace("\"","");
                        var handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(jwtToken);
                        _singletonService.Property = jwtToken; //token.Claims.First(claim => claim.Type == "role").Value;
                        return RedirectToAction(nameof(SalesDonoutsController.Index), "SalesDonouts");
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
            }
            catch (Exception ex)
            {
                return View(model);
            }
            return View(model);
        }
    }
}
