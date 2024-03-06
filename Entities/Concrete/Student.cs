using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Student :IEntity
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
    }
}
