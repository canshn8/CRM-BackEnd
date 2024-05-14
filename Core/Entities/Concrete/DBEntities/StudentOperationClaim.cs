using Core.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete.DBEntities
{
    public class StudentOperationClaim : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
