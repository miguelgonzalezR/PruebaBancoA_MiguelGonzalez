using Microsoft.AspNetCore.Mvc;
using PruebaBancoA_MiguelGonzalez.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PruebaBancoA_MiguelGonzalez.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var tarjetas = await GetTarjetasFromApi();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                tarjetas = tarjetas.Where(t =>
                    t.Trajeta.ToLower().Contains(search) ||
                    t.Nombre.ToLower().Contains(search) ||
                    t.Apellido.ToLower().Contains(search)
                ).ToList();
            }

            var pagedTarjetas = PaginatedList<Tarjetas>.Create(tarjetas.AsQueryable(), page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = pagedTarjetas.TotalPages;
            ViewBag.Search = search;

            return View(pagedTarjetas);
        }


        private async Task<List<Tarjetas>> GetTarjetasFromApi()
        {
            var response = await _httpClient.GetAsync("https://localhost:7161/api/Tarjetas"); // Ajusta la URL según sea necesario
            response.EnsureSuccessStatusCode();

            var tarjetas = await response.Content.ReadFromJsonAsync<List<Tarjetas>>();
            return tarjetas ?? new List<Tarjetas>();
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
