using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetById(string userId);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User>GetByMail(string email);
        IResult UserAdd(User user);
    }
}
