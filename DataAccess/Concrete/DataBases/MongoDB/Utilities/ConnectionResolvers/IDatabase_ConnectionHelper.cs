using Core.Utilities.Results;

namespace DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers
{
    public interface IDatabase_ConnectionHelper
    {
        IDataResult<DatabaseConnectionSettings> CheckDatabaseConnection();
    }
}