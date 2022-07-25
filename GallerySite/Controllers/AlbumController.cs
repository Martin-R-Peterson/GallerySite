using GallerySite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Net;

namespace GallerySite.Controllers
{
    public class AlbumController : Controller
    {
        static readonly HttpClient _httpClient = new HttpClient();
        public List<AlbumModel> _albums = new List<AlbumModel>();

        public AlbumController()
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            }
        }



        public async Task<IActionResult> Index(string? sort)
        {

            HttpResponseMessage responseMessage = await _httpClient.GetAsync("albums");
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseApi = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AlbumModel>>(responseApi);
                foreach (var item in result)
                {
                    if (ModelState.IsValid)
                    {
                        var albumTemp = new AlbumModel();
                        albumTemp.Title = item.Title;
                        albumTemp.Id = item.Id;
                        _albums.Add(albumTemp);
                    }



                }
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sort) ? "name_desc" : "";
                var albumsSort = from s in _albums
                                 select s;
                switch (sort)
                {
                    case "name_desc":
                        albumsSort = albumsSort.OrderByDescending(x => x.Title);
                        break;
                    default:
                        albumsSort = albumsSort.OrderBy(x => x.Title);
                        break;
                }
                return View(albumsSort);

            }
            return View(_albums);
        }


    }
}
