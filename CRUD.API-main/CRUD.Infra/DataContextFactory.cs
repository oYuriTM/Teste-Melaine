using CRUD.Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infra
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var cs = "Server=localhost\\SQLEXPRESS;Database=Client_Register;Trusted_Connection=True;TrustServerCertificate=true;";

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(cs)
                .Options;

            return new DataContext(options);
        }
    }
}
