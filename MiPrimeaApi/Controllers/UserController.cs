using Microsoft.AspNetCore.Mvc;
using MiPrimeaApi.Models;

namespace MiPrimeaApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private static List<ResponseUser> usuarios = new()
		{
			new ResponseUser { Id = 1, Name = "Juan", Age = 17, Categoria = "Menor de edad" },
			new ResponseUser { Id = 2, Name = "Maria", Age = 22, Categoria = "Mayor de edad" }
		};

		// GET /user
		[HttpGet]
		[Route("user")]
		public IEnumerable<ResponseUser> GetUsuarios()
		{
			return usuarios;
		}

		// POST /user/create
		[HttpPost]
		[Route("user/create")]
		public ActionResult<ResponseUser> CreateUsuario(RequestUser request)
		{
			if (request.Age < 0)
			{
				return BadRequest("La edad no puede ser negativa.");
			}

			var nuevoUsuario = new ResponseUser
			{
				Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1,
				Name = request.Name,
				Age = request.Age,
				Categoria = request.Age < 18 ? "Menor de edad" : "Mayor de edad"
			};

			usuarios.Add(nuevoUsuario);
			return nuevoUsuario;

			[HttpDelete]
			[Route("user/delete/{id}")]
			public IActionResult DeleteUsuario(int id)
			{
				var usuario = usuarios.FirstOrDefault(u => u.Id == id);
				if (usuario == null)
				{
					return NotFound($"No se encontró el usuario con ID {id}.");
				}

				usuarios.Remove(usuario);
				return NoContent(); // 204 sin contenido
			}
	}
}
