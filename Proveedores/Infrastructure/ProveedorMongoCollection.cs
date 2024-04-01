using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnicav2.Proveedores.Domain;

namespace PruebaTecnicav2.Proveedores.Infrastructure
{
    public class ProveedorMongoCollection : IProveedorCollection
    {
        internal MongoDB _Connection = new MongoDB("mongodb+srv://admin:zVLpXRVT5xcU1Vca@cluster0.5eyrhso.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0", "PruebaTecnicaDB");
        private IMongoCollection<Proveedor> Collection;// { get; set; }

        public ProveedorMongoCollection() 
        {
            Collection = _Connection.db.GetCollection<Proveedor>("Proveedores");
        }

        public async Task EliminarProveedor(string id)
        {
            var filter = Builders<Proveedor>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Proveedor>> ConsultarProveedores()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Proveedor> ConsultarProveedor(string id)
        {
            return await Collection.FindAsync(new BsonDocument { {"_id",new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<Proveedor> RegistrarProveedor(Proveedor proveedor)
        {
            await Collection.InsertOneAsync(proveedor);
            return proveedor;
        }

        public async Task ModificarProveedor(Proveedor proveedor)
        {
            var filter = Builders<Proveedor>.Filter.Eq(s => s.Id, proveedor.Id);
            await Collection.ReplaceOneAsync(filter,proveedor);
        }
    }
}
