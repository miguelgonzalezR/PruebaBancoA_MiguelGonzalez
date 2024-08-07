using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaBancoA_MiguelGonzalez.Models;

namespace PruebaBancoA_MiguelGonzalez.Controllers
{
    public class RegistroPagoController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegistroPagoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> AgregarPago(int tarjetaId)
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

                var pago = new Pagos
                {
                    TarjetaId = tarjetaR.Id,
                    Descripcion = "Pago de TC"

                };

                var viewModel = new TarjetaPagoViewModel
                {
                    Tarjeta = tarjetaR,
                    RPagos = pago
                };

                return View("AgregarPago", viewModel);
            }
            return NotFound();
        }


        [HttpPost("RegistrarC")]
        public async Task<IActionResult> RegistrarC(TarjetaPagoViewModel viewModel)
        {

            var pago = new Pagos
            {
                TarjetaId = viewModel.RPagos.TarjetaId,
                FechaCompra = viewModel.RPagos.FechaCompra,
                Monto = viewModel.RPagos.Monto,
                Descripcion = "Pago de TC"
            };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7161/api/Pagos", pago);
            if (response.IsSuccessStatusCode)
            {
                var createdCompra = await response.Content.ReadFromJsonAsync<Pagos>();
                return RedirectToAction("ConfirmarPago", new { tarjetaId = createdCompra.TarjetaId });
            }
            return BadRequest(response.Content.ReadAsStringAsync().Result);

        }

        [HttpGet("ConfirmarPago")]
        public IActionResult ConfirmarPago(int tarjetaId)
        {
            ViewBag.TarjetaId = tarjetaId;
            return View();
        }
    }

}
