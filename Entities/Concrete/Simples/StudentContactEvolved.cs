using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete.DBEntities;

namespace Entities.Concrete.Simples
{
    public class StudentContactEvolved
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
        public List<OperationClaim> OperationClaims { get; set; }
    }
}
