using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ManagementOfSantaClaus.Classes
{
  public class Toy
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("cost")]
    [BsonIgnoreIfNull]
    public decimal Cost { get; set; }

    [BsonElement("amount")]
    [BsonIgnoreIfNull]
    public int? Amount { get; set; }
  }
}
