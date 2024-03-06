using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        UserAccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
