using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicav2.Proveedores.Domain;

namespace PruebaTecnicav2.Proveedores.Application
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : Controller
    {
        private ProveedorService proveedorService = new ProveedorService();

        [HttpGet("ConsultarProveedores", Name = "ConsultarProveedores")]

        public async Task<IActionResult> ConsultarProveedores()
        {
            //HttpContext.Request.Headers.Add("Authorization", "Bearer " + token);
            return Ok(await proveedorService.ConsultarProveedores());
        }

        [HttpGet("ConsultarProveedor/{id}", Name = "ConsultarProveedor")]

        public async Task<IActionResult> ConsultarProveedor(string id)
        {
            return Ok(await proveedorService.ConsultarProveedor(id));
        }

        [HttpPost("RegistrarProveedor", Name = "RegistrarProveedor")]

        public async Task<IActionResult> RegistrarProveedor([FromBody] Domain.ProveedorInputModel proveedorInputModel)
        {
            if (proveedorInputModel == null)
                return BadRequest();
            return Created("Proveedor creado", await proveedorService.RegistrarProveedor(proveedorInputModel));
        }

        [HttpPut("ModificarProveedor", Name = "ModificarProveedor")]

        public async Task<IActionResult> ModificarProveedor([FromBody] Domain.Proveedor proveedor)
        {
            if (proveedor == null)
                return BadRequest();

            await proveedorService.ModificarProveedor(proveedor);
            return Created("Proveedor Modificado", true);
        }

        [HttpDelete("EliminarProveedor/{id}", Name = "EliminarProveedor")]

        public async Task<IActionResult> EliminarProveedor(string id)
        {
            await proveedorService.EliminarProveedor(id);
            return NoContent();
        }

    }
}
