using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {

        List<OperationClaim> GetClaims(Student student);
        List<StudentDetailsDto> GetAllStudent();
        List<StudentEvolved> GetAllWithClaims();
        StudentEvolved GetWithClaims(string studentId);
        StudentDto GetUserById(string id);
        StudentDetailsDto GetStudentById(string id);
        Student GetByMail(string email);
        void DeleteClaims(Student student);
        StudentClaimDto GetClaimAndStudentDetails(string email);

    }
}
