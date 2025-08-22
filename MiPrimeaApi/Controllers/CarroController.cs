using Microsoft.AspNetCore.Mvc;
using MiPrimeaApi.Models;
using System.Drawing;

namespace MiPrimeaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private static List<Carro> carros = new()
        {
            new Carro { Color = "Azul", Placa = "TX15", Id = 1},
            new Carro { Color = "Rojo", Placa = "XY95", Id = 2},
        };

        [HttpGet]
        [Route("GetCarro")]
        public IEnumerable<Carro> GetCarros()
        {
            return carros;
        }

        [HttpPost]
        [Route("CreateCarro")]
        public ActionResult<Carro> CreateCarro(Carro carro)
        {
            carros.Add(carro);
            return carro;
        }

        [HttpDelete]
        [Route("DeleteCarro")]
        public IActionResult DeleteCarro(int id)
        {
            var carro = carros.FirstOrDefault(c => c.Id == id);
            if (carro == null)
            {
                return NotFound($"No se encontro el carro con ID{id}.");
            }

            carros.Remove(carro);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateCarro")]
        public IActionResult UpdateCarro(Carro carroActualizado)
        {
            var carroExistente = carros.FirstOrDefault(c => c.Id == carroActualizado.Id);
            if (carroExistente == null)
            {
                return NotFound($"No se encontró el carro con ID {carroActualizado.Id}.");
            }

            carroExistente.Color = carroActualizado.Color;
            carroExistente.Placa = carroActualizado.Placa;

            return Ok(carroExistente);
        }
    }
}
