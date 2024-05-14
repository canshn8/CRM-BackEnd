using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class StudentContactManager : IStudentContactService
    {
        IStudentContactDal _studentContactDal;
        public StudentContactManager(IStudentContactDal studentContactDal)
        {
            _studentContactDal = studentContactDal;
        }
        public IDataResult<List<OperationClaim>> GetClaimsContact(StudentContact studentContact)
        {
            return new SuccessDataResult<List<OperationClaim>>(_studentContactDal.GetClaimsContact(studentContact), Messages.Successful);
        }

        public IResult AddContact(StudentContact studentContact)
        {
            IResult result = BusinessRules.Run(StudentExistsContact(studentContact.Id));
            if (result != null)
            {
                return result;
            }
            _studentContactDal.AddContact(studentContact);
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<List<StudentContactDto>> GetAllContact()
        {
            return new SuccessDataResult<List<StudentContactDto>>(_studentContactDal.GetAllStudentContact(), Messages.Successful);

        }

        private IResult StudentExistsContact(string id)
        {
            var result = _studentContactDal.GetUserByIdContact(id);
            if (result != null)
            {
                return new ErrorResult(Messages.StudentAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }
    }
}
