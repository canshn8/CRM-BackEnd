using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

using DataAccess.Abstract;
using Core.Entities.Concrete.DBEntities;
using Business.Constants;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
            private readonly IUserDal _userDal;

            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),"başarılı");
        }

        public IDataResult<User> GetById(string userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(i=>i.Id==userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(i=>i.Email==email));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public IResult UserAdd(User user)
        {
            var result = BusinessRules.Run(UserExists(user.Email));
            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult();
        }
        private IResult UserExists(string mail)
        {
            var result=GetByMail(mail);
            if (result.Data!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
