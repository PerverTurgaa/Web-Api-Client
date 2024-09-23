using AspClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace AspClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var products = new List<ProductDTO>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7053/api/products"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("API Yanýtý: " + apiResponse); 

                        if (!string.IsNullOrWhiteSpace(apiResponse))
                        {
                            try
                            {
                                products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
                            }
                            catch (JsonException ex)
                            {
                                Console.WriteLine($"JSON deserialization hatasý: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("API yanýtý boþ.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Hata: {response.StatusCode}");
                    }
                }
            }

            return View(products);
        }

    }
}
