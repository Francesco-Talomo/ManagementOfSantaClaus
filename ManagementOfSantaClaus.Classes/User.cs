using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ManagementOfSantaClaus.Classes
{
  public class User
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }

    [BsonElement("screenname")]
    public string ScreenName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("isAdmin")]
    public bool IsAdmin { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("password_clear_text")]
    public string PasswordClearText { get; set; }
  }
}
