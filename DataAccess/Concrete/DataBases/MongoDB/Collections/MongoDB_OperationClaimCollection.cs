namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_OperationClaimCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_OperationClaimCollection()
        {
            CollectionName = "OperationClaims";
        }
    }
}