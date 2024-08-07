using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using PruebaBancoA_MiguelGonzalez.Models;
using System.Net.Http;
using System.Text.Json;

namespace PruebaBancoA_MiguelGonzalez.Controllers
{
    public class EstadoCuentaController : Controller
    {

        private readonly HttpClient _httpClient;

        public EstadoCuentaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: EstadoCuentaController1
        public async Task<IActionResult> Detalle(string tarjetaId)
        {
            var responseCom = await _httpClient.GetAsync($"https://localhost:7161/api/Compras/Tarjeta/{tarjetaId}");
            responseCom.EnsureSuccessStatusCode();

            var estadoCuenta = await responseCom.Content.ReadFromJsonAsync<TarjetaEC>();

            if (estadoCuenta == null)
            {
                return BadRequest("Error al obtener los datos del estado de cuenta.");
            }

            return View("Detalle", estadoCuenta);
        }



    }
}
