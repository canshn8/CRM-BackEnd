using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudentDetailsDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PaymentMethod{ get; set; }
        public DateTime PaymentHistory{ get; set; }
        public decimal Collection{ get; set; }
        public string Report { get; set; }

        public bool Status { get; set; }
    }
}
