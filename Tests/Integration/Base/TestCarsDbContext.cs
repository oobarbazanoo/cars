using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Tests.Integration.Base
{
    public class TestCarsDbContext : CarsDbContext
    {
        readonly InMemorySetup Setup;
        public TestCarsDbContext(IConfiguration config, InMemorySetup setup) : base(config)
        {
            Setup = setup;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase(Setup.DbName);
            options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
}