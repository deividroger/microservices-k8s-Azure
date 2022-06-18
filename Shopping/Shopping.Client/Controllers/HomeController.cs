using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Data;
using Shopping.Client.Models;
using System.Diagnostics;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ShoppingAPIClient");
        }

        public async  Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("/api/Product");
            var content = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);


            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}