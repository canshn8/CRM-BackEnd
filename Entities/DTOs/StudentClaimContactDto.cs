using Core.Entities.Concrete.DBEntities;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class StudentClaimContactDto
    {
        public string StudentId { get; set; }
        public decimal No { get; set; }
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
