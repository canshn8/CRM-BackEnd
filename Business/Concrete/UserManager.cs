﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.Text;

using DataAccess.Abstract;
using Core.Entities.Concrete.DBEntities;
using Business.Constants;
using Core.Utilities.Business;
=======
>>>>>>> Stashed changes

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

<<<<<<< Updated upstream
=======
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

      
>>>>>>> Stashed changes
        public IResult Delete(User user)
        {
            var claims = GetClaims(user);
            var claim = claims.Data.Find(c => c.Name == "suser");
            if (claim == null)
            {
                var result = _userDal.Delete(user.Id);
                if (result.DeletedCount > 0)
                {
                    _userDal.DeleteClaims(user);

                    return new SuccessResult(Messages.Successful);
                }
                throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);

            }
            return new ErrorResult(Messages.SuperUserCannotBeDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),"başarılı");
        }

        public IDataResult<UserEvolved> GetById(string id)
        {
            return new SuccessDataResult<UserEvolved>(_userDal.GetWithClaims(id), Messages.Successful);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

<<<<<<< Updated upstream
        public List<OperationClaim> GetClaims(User user)
=======
        public IDataResult<UserClaimDto> GetClaimAndUserDetails(string mail)
        {
            return new SuccessDataResult<UserClaimDto>(_userDal.GetClaimAndUserDetails(mail), Messages.Successful);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.Successful);
        }

        public IDataResult<UserDto> GetDetailsById(string id)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserById(id), Messages.Successful);
        }

        public IDataResult<UserDto> Update(UserDto user)
>>>>>>> Stashed changes
        {
            var currentUser = GetByMail(user.Email);
            currentUser.Data.Email = user.Email;
            currentUser.Data.FirstName = user.FirstName;
            currentUser.Data.LastName = user.LastName;
            currentUser.Data.Status = user.Status;

            var result = _userDal.Update(currentUser.Data);
            if (result.MatchedCount > 0)
            {
                return new SuccessDataResult<UserDto>(user, Messages.UserUpdated);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
<<<<<<< Updated upstream
        private IResult UserExists(string mail)
=======


        private IResult UserExists(string email)
>>>>>>> Stashed changes
        {
            var result = GetByMail(email);
            if (result.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }
    }
}
