using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace storageCRUD.Models;

public class Product {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id {get; set;}

    [BsonElement("name")]
    public string? name {get; set;}

    [BsonElement("description")]
    public string? description {get; set;}

    [BsonElement("price")]
    public int price {get; set;}

    [BsonElement("amount")]
    public int amount {get; set;}

}