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
    public class StudentStartingManager : IStudentStartingService
    {
        IStudentStartingDal _studentStartingDal;

        public StudentStartingManager(IStudentStartingDal studentStartingDal)
        {
            _studentStartingDal = studentStartingDal;
        }
        public IDataResult<List<OperationClaim>> GetClaimsStarting(StudentStarting studentStarting)
        {
            return new SuccessDataResult<List<OperationClaim>>(_studentStartingDal.GetClaimsStarting(studentStarting), Messages.Successful);
        }
        public IResult AddStarting(StudentStarting studentStarting)
        {
            IResult result = BusinessRules.Run(StudentExistsStarting(studentStarting.Id));
            if (result != null)
            {
                return result;
            }
            _studentStartingDal.AddStarting(studentStarting);
            return new SuccessResult(Messages.Successful);
        }
        public IDataResult<List<StudentStartingDto>> GetAllStarting()
        {
            return new SuccessDataResult<List<StudentStartingDto>>(_studentStartingDal.GetAllStudentStarting(), Messages.Successful);

        }
        private IResult StudentExistsStarting(string id)
        {
            var result = _studentStartingDal.GetUserByIdStarting(id);
            if (result != null)
            {
                return new ErrorResult(Messages.StudentAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }
    }
}
