using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.DataAccess.Databases;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Utilities.Business;
using Entities.Concrete;
using Core.Entities.Concrete.DBEntities;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
           _studentDal = studentDal;
        }

        public List<OperationClaim> GetClaims(Student student)
        {
            return _studentDal.GetClaims(student);
        }

        //public IResult Add(Student student)
        //{
        //    _studentDal.Add(student);
        //}
        public IDataResult<Student> GetById(int studentId)
        {
<<<<<<< Updated upstream
            throw new NotImplementedException();
=======
            IResult result = BusinessRules.Run(StudentExists(student.Id));

            if (result != null)
            {
                return result;
            }
            _studentDal.Add(student);

            return new SuccessResult(Messages.Successful);
>>>>>>> Stashed changes
        }

        public IResult Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetByMail(string email)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
