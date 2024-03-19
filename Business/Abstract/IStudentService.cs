using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IDataResult<List<OperationClaim>> GetClaims(Student student);
        IResult Add(Student student);
        IDataResult<StudentEvolved> GetById(string studentId);
        IResult Delete(Student student);
        IDataResult<List<StudentDetailsDto>> GetAll();
        IDataResult<Student> GetByMail(string email);

    }
}
