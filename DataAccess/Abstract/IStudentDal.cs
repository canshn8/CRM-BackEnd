using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using Entities.DTOs;
using System.Text;
using Entities.Concrete.Simples;

namespace DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
        List<OperationClaim> GetClaims(Student student);
        List<StudentDetailsDto> GetAllStudent();
        List<StudentEvolved> GetAllWithClaims();
        StudentEvolved GetWithClaims(string studentId);
        void DeleteClaims(Student student);
        StudentClaimDto GetClaimAndStudentDetails(string email);

    }
}
