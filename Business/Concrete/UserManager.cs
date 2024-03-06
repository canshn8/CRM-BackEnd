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
using Entities.DTOs;
using Entities.Concrete.Simples;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
            private readonly IUserDal _userDal;

            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }

        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(UserExists(user.Email));

            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);

            return new SuccessResult(Messages.Successful);
        }
        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserDetailsDto>> GetAll()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetAllUser(), Messages.Successful);
        }

        public IDataResult<User> GetById(string userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(i=>i.Id==userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(i=>i.Email==email));
        }

        public IDataResult<UserClaimDto> GetClaimAndUserDetails(string mail)
        {
            return new SuccessDataResult<UserClaimDto>(_userDal.GetClaimAndUserDetails(mail), Messages.Successful);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), "tamamdır");
        }

        public IDataResult<UserDto> GetDetailsById(string id)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserById(id), Messages.Successful);
        }

        public IDataResult<UserDto> Update(UserDto user)
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


        //IDataResult<UserEvolved> IUserService.GetById(string id)
        //{
        //    throw new NotImplementedException();
        //}HATAAAALIII

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
