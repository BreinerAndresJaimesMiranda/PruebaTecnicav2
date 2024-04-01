using PruebaTecnica.Proveedores.Domain;

namespace PruebaTecnica.Proveedores.Infrastructure
{
    public interface IProveedorCollection
    {
        Task RegistrarProveedor(Proveedor proveedor);
        Task ModificarProveedor(Proveedor proveedor);
        Task EliminarProveedor(string id);
        Task<List<Proveedor>> ConsultarProveedores();
        Task<Proveedor> ConsultarProveedor(string id);
    }
}
