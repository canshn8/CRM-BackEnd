using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudentForAddDto : IDto
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public DateTime SalesTime { get; set; }
        public string Collection { get; set; }
    }
}
