using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using Entities.DTOs;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        UserDto GetUserById(string id);

    }
}
