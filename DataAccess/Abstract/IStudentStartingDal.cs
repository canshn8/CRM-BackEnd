using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
