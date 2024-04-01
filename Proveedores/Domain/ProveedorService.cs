using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnicav2.Proveedores.Infrastructure;
using PruebaTecnicav2.Proveedores.Domain;

namespace PruebaTecnicav2.Proveedores.Domain
{
    public class ProveedorService
    {
        private IProveedorCollection ProveedorCollection= new ProveedorMongoCollection();
        public async Task EliminarProveedor(string id)
        {
            await ProveedorCollection.EliminarProveedor(id);
        }

        public async Task<List<ProveedorViewModel>> ConsultarProveedores()
        {
            List<Proveedor> proveedores = await ProveedorCollection.ConsultarProveedores();
            List<ProveedorViewModel> proveedoresViewModel = new List<ProveedorViewModel>();
            for (int i = 0; i<proveedores.Count; i++)
            {
                proveedoresViewModel.Add(MapearProveedorViewModel(proveedores[i]));
            }
            return proveedoresViewModel;
        }

        public async Task<ProveedorViewModel> ConsultarProveedor(string id)
        {
            return MapearProveedorViewModel(await ProveedorCollection.ConsultarProveedor(id));
        }

        public async Task<ProveedorViewModel> RegistrarProveedor(ProveedorInputModel proveedorInputModel)
        {
            Proveedor proveedor = MapearProveedor(proveedorInputModel);

            ProveedorViewModel proveedorViewModel = MapearProveedorViewModel(await ProveedorCollection.RegistrarProveedor(proveedor));
            return proveedorViewModel;
        }

        public async Task<ProveedorViewModel> ModificarProveedor(ProveedorInputModel proveedorInputModel,string Id)
        {
            Proveedor proveedor = MapearProveedor(proveedorInputModel);
            ProveedorViewModel proveedorViewModel;
            await ProveedorCollection.ModificarProveedor(proveedor,Id);
            proveedorViewModel = MapearProveedorViewModel(proveedor);
            proveedorViewModel.Id= Id;
            return proveedorViewModel;
        }

        private Proveedor MapearProveedor(ProveedorInputModel proveedorInputModel)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.NIT = proveedorInputModel.NIT;
            proveedor.RazonSocial = proveedorInputModel.RazonSocial;
            proveedor.Direccion = proveedorInputModel.Direccion;
            proveedor.Ciudad = proveedorInputModel.Ciudad;
            proveedor.Departamento = proveedorInputModel.Departamento;
            proveedor.Correo = proveedorInputModel.Correo;
            proveedor.Activo = proveedorInputModel.Activo;
            proveedor.FechaCreacion = proveedorInputModel.FechaCreacion;
            proveedor.NombreContacto = proveedorInputModel.NombreContacto;
            proveedor.CorreoContacto = proveedorInputModel.CorreoContacto;
            return proveedor;
        }

        private ProveedorViewModel MapearProveedorViewModel(Proveedor proveedor)
        {
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel();
            proveedorViewModel.Id=proveedor.Id.ToString();
            proveedorViewModel.NIT = proveedor.NIT;
            proveedorViewModel.RazonSocial = proveedor.RazonSocial;
            proveedorViewModel.Direccion = proveedor.Direccion;
            proveedorViewModel.Ciudad = proveedor.Ciudad;
            proveedorViewModel.Departamento = proveedor.Departamento;
            proveedorViewModel.Correo = proveedor.Correo;
            proveedorViewModel.Activo = proveedor.Activo;
            proveedorViewModel.FechaCreacion = proveedor.FechaCreacion;
            proveedorViewModel.NombreContacto = proveedor.NombreContacto;
            proveedorViewModel.CorreoContacto = proveedor.CorreoContacto;
            return proveedorViewModel;
        }

    }
}
