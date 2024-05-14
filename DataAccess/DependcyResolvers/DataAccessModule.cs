using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyResolvers
{
    public class DataAccessModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection services)
        {
        }
    }
}