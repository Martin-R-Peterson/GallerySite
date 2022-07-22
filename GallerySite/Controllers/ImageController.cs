using GallerySite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GallerySite.Controllers
{
    public class ImageController : Controller
    {
        static readonly HttpClient _httpClient = new HttpClient();

        public ImageController()
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            }
        }


        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"albums/{id}/photos");
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseApi = await responseMessage.Content.ReadAsStringAsync();
                var imgList = JsonConvert.DeserializeObject<IEnumerable<ImageModel>>(responseApi);

                return View(imgList);
            }
            return View();
        }

    }
}
