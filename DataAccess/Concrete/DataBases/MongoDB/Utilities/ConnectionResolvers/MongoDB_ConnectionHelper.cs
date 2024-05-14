using Core.Utilities.IoC;
using Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers
{
    public class MongoDB_ConnectionHelper : IDatabase_ConnectionHelper
    {
        private readonly IConfiguration configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        private readonly CompressionSetting databaseConnectionSettings;
        public MongoDB_ConnectionHelper()
        {
            databaseConnectionSettings = configuration.GetSection(nameof(CompressionSetting)).Get<CompressionSetting>();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        }

        public IDataResult<DatabaseConnectionSettings> CheckDatabaseConnection()
        {
            return new SuccessDataResult<DatabaseConnectionSettings>(new DatabaseConnectionSettings { HostName = $"mongodb://" + Environment.GetEnvironmentVariable("DATABASE_HOSTNAME"), Database = databaseConnectionSettings.Database });
        }
    }
}