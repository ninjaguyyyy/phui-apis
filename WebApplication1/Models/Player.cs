using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuiAPIs.Models
{
  public class Player
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public String Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("yearOfBirth")]
    public string YearOfBirth { get; set; }
  }
}
