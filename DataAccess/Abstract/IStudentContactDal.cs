using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IStudentContactDal : IEntityRepository<StudentContact>
    {
        List<StudentContactDto> GetAllStudentContact();
        List<OperationClaim> GetClaimsContact(StudentContact studentContact);
        List<StudentContactEvolved> GetAllWithClaimsContact();
        StudentContactDto GetUserByIdContact(string id);

    }
}
