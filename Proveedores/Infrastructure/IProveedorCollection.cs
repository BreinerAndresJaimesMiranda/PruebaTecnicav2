using PruebaTecnicav2.Proveedores.Domain;

namespace PruebaTecnicav2.Proveedores.Infrastructure
{
    public interface IProveedorCollection
    {
        Task<Proveedor> RegistrarProveedor(Proveedor proveedor);
        Task ModificarProveedor(Proveedor proveedor,String Id);
        Task EliminarProveedor(string id);
        Task<List<Proveedor>> ConsultarProveedores();
        Task<Proveedor> ConsultarProveedor(string id);
    }
}
