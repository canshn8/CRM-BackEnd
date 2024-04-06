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
        IResult Delete(string id);
        IDataResult<Student> GetByMail(string email);
        IResult Update(Student student);
        IDataResult<List<StudentDetailsDto>> GetAll();

    }
}
