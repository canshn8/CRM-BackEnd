using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
        List<OperationClaim> GetClaims(Student student);

    }
}
