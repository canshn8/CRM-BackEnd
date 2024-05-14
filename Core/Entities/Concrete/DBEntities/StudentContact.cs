using Core.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete.DBEntities
{
    public class StudentContact : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Staff { get; set; }
        public string DataSource { get; set; }
        public string InterestedEducation { get; set; }
        public string CareerCounselor { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }

    }
}
