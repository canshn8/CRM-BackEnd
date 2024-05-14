using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class StudentContactDto : IDto
    {
        public decimal No { get; set; }
        public string Name { get; set; }
        public string Staff { get; set; }
        public string DataSource { get; set; }
        public string InterestedEducation { get; set; }
        public string CareerCounselor { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
