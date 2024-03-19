using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_UserDal : MongoDB_RepositoryBase<User, MongoDB_Context<User, MongoDB_UserCollection>>, IUserDal
    {
        public void DeleteClaims(User user)
        {
            throw new NotImplementedException();
        }

        public List<UserDetailsDto> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public List<UserEvolved> GetAllWithClaims()
        {
            throw new NotImplementedException();
        }

        public UserClaimDto GetClaimAndUserDetails(string email)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public UserEvolved GetWithClaims(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
