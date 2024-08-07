using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaBancoA_MiguelGonzalez.Models;
using System.Text.Json;

namespace PruebaBancoA_MiguelGonzalez.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly HttpClient _httpClient;

        public MovimientosController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: MovimientosController
        public async Task<IActionResult> Movimientos(string tarjetaId)
        {
            var responseTar = await _httpClient.GetAsync($"https://localhost:7161/api/Tarjetas/{tarjetaId}");
            responseTar.EnsureSuccessStatusCode();


            var tarjeta = await responseTar.Content.ReadFromJsonAsync<Tarjetas>();

            var tarjetaR = new Tarjetas
            {
                Id = tarjeta.Id,
                Trajeta = tarjeta.Trajeta,
                Nombre = tarjeta.Nombre,
                Apellido = tarjeta.Apellido
            };

            var responseCom = await _httpClient.GetAsync($"https://localhost:7161/api/Movimientos/Tarjeta/{tarjetaId}"); // Ajusta la URL según sea necesario
            responseCom.EnsureSuccessStatusCode();


            var content = await responseCom.Content.ReadAsStringAsync();

            List<Movimientos> movi = new List<Movimientos>();

            if (!string.IsNullOrEmpty(content))
            {
                movi = JsonSerializer.Deserialize<List<Movimientos>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }


            var historialViewModel = new List<MovimientosViewModel>
            {
                new MovimientosViewModel
                {
                    Tarjeta = tarjetaR,
                    Movi = movi
                }
            };



            var Moviemientos = historialViewModel;
            return View("Movimientos", Moviemientos);
        }

        // GET: MovimientosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
