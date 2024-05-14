namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_StudentContactCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_StudentContactCollection()
        {
            CollectionName = "StudentContact";
        }
    }
}
