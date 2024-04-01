using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Proveedores.Domain;

namespace PruebaTecnica.Proveedores.Application
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : Controller
    {
        private ProveedorService proveedorService = new ProveedorService();

        [HttpGet]
        public async Task<IActionResult> ConsultarProveedores()
        {
            return Ok(await proveedorService.ConsultarProveedores());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarProveedor(string id)
        {
            return Ok(await proveedorService.ConsultarProveedor(id));
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarProveedor([FromBody] Domain.Proveedor proveedor)
        {
            if (proveedor == null)
                return BadRequest();

            await proveedorService.RegistrarProveedor(proveedor);
            return Created("Proveedor creado", true);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarProveedor([FromBody] Domain.Proveedor proveedor)
        {
            if (proveedor == null)
                return BadRequest();

            await proveedorService.ModificarProveedor(proveedor);
            return Created("Proveedor Modificado", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProveedor(string id)
        {
            await proveedorService.EliminarProveedor(id);
            return NoContent();
        }

    }
}
