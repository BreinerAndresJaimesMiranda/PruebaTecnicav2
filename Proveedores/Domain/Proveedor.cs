using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PruebaTecnicav2.Proveedores.Domain;

namespace PruebaTecnicav2.Proveedores.Domain
{
    public class Proveedor:ProveedorInputModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
