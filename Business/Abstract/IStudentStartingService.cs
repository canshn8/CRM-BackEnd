using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStudentStartingService
    {
        IDataResult<List<OperationClaim>> GetClaimsStarting(StudentStarting studentStarting);
        IResult AddStarting(StudentStarting studentStarting);
        IDataResult<List<StudentStartingDto>> GetAllStarting();
    }
}
