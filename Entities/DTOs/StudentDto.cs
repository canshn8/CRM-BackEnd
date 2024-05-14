using Core.Entities.Abstract;
using System;

namespace Entities.DTOs
{
    public class StudentDto : IDto
    {
        //public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string No { get; set; }
        public string InterestedEducation { get; set; }
        public string DataSource { get; set; }
        public string IsReg { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentHistory { get; set; }
        public decimal Collection { get; set; }
        public string Report { get; set; }
        public bool Status { get; set; }


    }
}
