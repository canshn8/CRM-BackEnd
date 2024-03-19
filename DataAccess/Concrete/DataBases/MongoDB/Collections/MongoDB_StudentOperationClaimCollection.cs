using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_StudentOperationClaimCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_StudentOperationClaimCollection()
        {
            CollectionName = "StudentOperationClaims";
        }
    }
}
