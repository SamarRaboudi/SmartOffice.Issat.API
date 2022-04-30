using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace SmartOffice.Issat.API.Models
{
    public class UserDefinition
    {
        
        // public string Id { get; set; }
        [BsonId]
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Password")]
        public String Password { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }

    }

}
