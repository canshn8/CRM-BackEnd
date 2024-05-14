namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_StudentStartingCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_StudentStartingCollection()
        {
            CollectionName = "StudentStarting";
        }
    }
}
