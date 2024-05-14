using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStudentContactService
    {
        IDataResult<List<OperationClaim>> GetClaimsContact(StudentContact studentContact);
        IDataResult<List<StudentContactDto>> GetAllContact();
        IResult AddContact(StudentContact studentContact);
    }
}
