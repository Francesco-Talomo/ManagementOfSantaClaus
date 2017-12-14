using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ManagementOfSantaClaus.Classes
{
  public class Order
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }

    [BsonElement("kid")]
    public string Kid { get; set; }

    [BsonElement("status")]
    public bool Status { get; set; }

    [BsonElement("toy")]
    public List<Toy> Toys { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    [BsonElement("requestDate")]
    public DateTime Date { get; set; }
  }
}
