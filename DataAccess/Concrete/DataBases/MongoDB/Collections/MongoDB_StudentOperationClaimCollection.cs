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
