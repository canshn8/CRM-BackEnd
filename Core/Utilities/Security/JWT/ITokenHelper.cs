using Core.Entities.Concrete.DBEntities;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        UserAccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
