using System.Text.Json.Serialization;
using CRUDAppUsingASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDAppUsingASPCoreWebAPI.Controllers
{
    public class ProductController : Controller
    {
        private string url = "https://localhost:7244/api/ProductAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Product>>(result);
                if(data != null)
                {
                    products = data;
                }
            }
            return View(products);
        }
    }
}
