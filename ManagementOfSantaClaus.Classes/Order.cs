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
    public string Id { get; set; }

    [BsonElement("kid")]
    public string Kid { get; set; }

    [BsonElement("status")]
    public StatusType Status { get; set; }

    [BsonElement("toys")]
    public List<Toy> Toys { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    [BsonElement("requestDate")]
    public DateTime Date { get; set; }
  }
}
