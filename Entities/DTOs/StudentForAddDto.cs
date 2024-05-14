using Core.Entities.Abstract;
using System;

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
