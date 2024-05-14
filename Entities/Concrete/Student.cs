using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Student : IEntity
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
    }
}
