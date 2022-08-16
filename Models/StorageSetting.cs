
namespace storageCRUD.Models;

public class StorageSettings : IStorageSettings {

    public string? Server {get; set;}
    public string? Database {get; set;}
    public string? Collection {get; set;}

}

public interface IStorageSettings {
    
    string? Server {get; set;}
    string? Database {get; set;}
    string? Collection {get; set;}

}