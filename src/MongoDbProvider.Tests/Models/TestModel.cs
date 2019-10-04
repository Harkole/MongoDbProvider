using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProvider.Tests.Models
{
    public class TestModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        public string Name {get;set;}
        public int Age {get;set;}
    }
}