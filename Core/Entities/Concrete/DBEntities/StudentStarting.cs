using Core.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Core.Entities.Concrete.DBEntities
{
    public class StudentStarting : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public decimal Tc { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int No { get; set; }
        public string Location { get; set; }
        public int CollectionAmount { get; set; }
        public int AdvancePay { get; set; }
        public DateTime EducationHistory { get; set; }
        public DateTime RegHistory { get; set; }
        public string Staff { get; set; }
        public string DataSource { get; set; }
        public string CareerCounselor { get; set; }
        public string InterestedEducation { get; set; }
        public string NumberBills { get; set; }
        public bool Status { get; set; }

    }
}
