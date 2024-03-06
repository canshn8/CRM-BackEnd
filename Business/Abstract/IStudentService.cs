using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudentService
    {
        List<OperationClaim> GetClaims(Student student);
        IResult Add(Student student);
        IDataResult<Student> GetById(int studentId);
        IResult Delete(Student student);
        IDataResult<List<Student>> GetAll();
        Student GetByMail(string email);
    }
}
