using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_StudentCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_StudentCollection()
        {
            CollectionName = "Students";
        }
    }
}
