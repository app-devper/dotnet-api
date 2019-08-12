using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("phone")]
        public string Phone { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }
        [BsonElement("role")]
        public string Role { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; }
        [BsonElement("countLoginFailed")]
        public int CountLoginFailed { get; set; }
        [BsonElement("timeToUnlock")]
        public DateTime TimeToUnlock { get; set; }
        [BsonElement("createdBy")]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string CreatedBy { get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("updatedBy")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UpdatedBy { get; set; }
        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; }
    }
}
