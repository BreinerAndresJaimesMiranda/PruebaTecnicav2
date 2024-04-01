using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnica.Proveedores.Infrastructure;

namespace PruebaTecnica.Proveedores.Domain
{
    public class ProveedorService
    {
        private IProveedorCollection ProveedorCollection= new ProveedorMongoCollection();
        public async Task EliminarProveedor(string id)
        {
            await ProveedorCollection.EliminarProveedor(id);
        }

        public async Task<List<Proveedor>> ConsultarProveedores()
        {
            return await ProveedorCollection.ConsultarProveedores();
        }

        public async Task<Proveedor> ConsultarProveedor(string id)
        {
            return await ProveedorCollection.ConsultarProveedor(id);
        }

        public async Task RegistrarProveedor(Proveedor proveedor)
        {
            await ProveedorCollection.RegistrarProveedor(proveedor);
        }

        public async Task ModificarProveedor(Proveedor proveedor)
        {
            await ProveedorCollection.ModificarProveedor(proveedor);
        }

    }
}
