using MongoDB.Driver;

namespace PruebaTecnica.Proveedores.Infrastructure
{
    //CADENA DE CONEXION: mongodb://localhost:27017
    //BASE DE DATOS: PruebaTecnicaDB
    public class MongoDB
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDB(string connectionString, string NameDB)
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(NameDB);
        }
    }
}
