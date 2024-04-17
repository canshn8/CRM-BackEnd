using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudentContactDto : IDto
    {
        public string Id { get; set; }
        public int No{ get; set; }
        public string Name { get; set; }
        public string Staff { get; set; }
        public string DataSource { get; set; }
        public string InterestedEducation { get; set; }
        public string CareerCounselor { get; set; }
        public string Comment { get; set; }
        public bool Status {  get; set; }
    }
}
