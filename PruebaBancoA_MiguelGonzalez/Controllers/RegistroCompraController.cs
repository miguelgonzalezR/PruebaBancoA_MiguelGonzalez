using Microsoft.AspNetCore.Mvc;
using PruebaBancoA_MiguelGonzalez.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PruebaBancoA_MiguelGonzalez.Controllers
{
    public class RegistroCompraController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegistroCompraController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> AgregarRCompra(int tarjetaId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7161/api/Tarjetas/{tarjetaId}");
            if (response.IsSuccessStatusCode)
            {
                var tarjeta = await response.Content.ReadFromJsonAsync<Tarjetas>();

                var tarjetaR = new Tarjetas
                {
                    Id = tarjeta.Id,
                    Trajeta = tarjeta.Trajeta,
                    Nombre = tarjeta.Nombre,
                    Apellido = tarjeta.Apellido
                };

                var compra = new RCompra
                {
                    TarjetaId = tarjetaR.Id,
                };

                var viewModel = new TarjetaRCompraViewModel
                {
                    Tarjeta = tarjetaR,
                    RCompra = compra
                };

                return View("AgregarRCompra", viewModel);
            }
            return NotFound();
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(TarjetaRCompraViewModel viewModel)
        {

            var compra = new RCompra
            {
                TarjetaId = viewModel.RCompra.TarjetaId,
                FechaCompra = viewModel.RCompra.FechaCompra,
                Monto = viewModel.RCompra.Monto,
                Descripcion = viewModel.RCompra.Descripcion
            };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7161/api/Compras", compra);
            if (response.IsSuccessStatusCode)
            {
                var createdCompra = await response.Content.ReadFromJsonAsync<RCompra>();
                return RedirectToAction("ConfirmacionCompra", new { tarjetaId = createdCompra.TarjetaId });
            }
            return BadRequest(response.Content.ReadAsStringAsync().Result);

        }

        [HttpGet("ConfirmacionCompra")]
        public IActionResult ConfirmacionCompra(int tarjetaId)
        {
            ViewBag.TarjetaId = tarjetaId;
            return View();
        }
    }
}
