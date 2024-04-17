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
        IDataResult<List<OperationClaim>> GetClaimsStarting(StudentStarting studentStarting);
        IDataResult<List<OperationClaim>> GetClaimsContact(StudentContact studentContact);
        IResult Add(Student student);
        IResult AddStarting(StudentStarting studentStarting);
        IResult AddContact(StudentContact studentContact);
        IDataResult<StudentEvolved> GetById(string studentId);
        IResult Delete(string id);
        IDataResult<Student> GetByMail(string email);
        IResult Update(Student student);
        IDataResult<List<StudentDetailsDto>> GetAll();
        IDataResult<List<StudentContactDto>> GetAllContact();
        IDataResult<List<StudentStartingDto>> GetAllStarting();

    }
}
