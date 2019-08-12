using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Entities
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("senderId")]
        public string SenderId { get; set; }
        [BsonElement("profilePic")]
        public string ProfilePic { get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
