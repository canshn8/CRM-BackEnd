using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_UserDal : MongoDB_RepositoryBase<User, MongoDB_Context<User, MongoDB_UserCollection>>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
