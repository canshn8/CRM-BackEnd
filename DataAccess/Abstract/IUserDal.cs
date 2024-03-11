using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using Entities.DTOs;
using System.Text;
using Entities.Concrete.Simples;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDetailsDto> GetAllUser();
        UserDto GetUserById(string id);
        List<UserEvolved> GetAllWithClaims();
        List<OperationClaim> GetClaims(User user);
        UserEvolved GetWithClaims(string userId);
        void DeleteClaims(User user);
        UserClaimDto GetClaimAndUserDetails(string email);

    }
}
