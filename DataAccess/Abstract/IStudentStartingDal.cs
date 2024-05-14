using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IStudentStartingDal : IEntityRepository<StudentStarting>
    {
        List<StudentStartingDto> GetAllStudentStarting();
        StudentStartingDto GetUserByIdStarting(string id);
        List<StudentStartingEvolved> GetAllWithClaimsStarting();
        List<OperationClaim> GetClaimsStarting(StudentStarting studentStarting);


    }
}
