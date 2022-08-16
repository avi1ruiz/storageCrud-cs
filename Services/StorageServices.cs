using MongoDB.Driver;
using storageCRUD.Models;

namespace storageCRUD.Services;

public class StorageServices {

    private IMongoCollection<Product> _products;

    public StorageServices(IStorageSettings settings){
        // Acceso a la base de datos        
        var client = new MongoClient(settings.Server);
        var database = client.GetDatabase(settings.Database);
        _products = database.GetCollection<Product>(settings.Collection);
    
    }

    // Listar documentos de la base de datos
    public Task<List<Product>> GetAllAsync() => _products.Find(_ => true).ToListAsync();
    // Mostrar un documento de la base de datos
    public Task<Product> GetByIdAsync(string id) => _products.Find(x => x.id == id).FirstOrDefaultAsync();
    // Agregar documento a la base de datos
    public async Task AddAsync(Product productAdd) => await _products.InsertOneAsync(productAdd);
    // Eliminar documento de la base de datos
    public Task DeleteAsync(string? id) => _products.DeleteOneAsync(x => x.id == id);
    // Actualizar documento de la base de datos
    public Task UpdateAsync(string id, Product productUpdate) => _products.ReplaceOneAsync(x => x.id == id, productUpdate);
}