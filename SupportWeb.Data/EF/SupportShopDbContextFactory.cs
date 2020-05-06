using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SupportWeb.Data.EF
{
    public class SupportShopDbContextFactory : IDesignTimeDbContextFactory<SupportShopDbContext>
    {
        public SupportShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var connectionString = configuration.GetConnectionString("SupportShopDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<SupportShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SupportShopDbContext(optionsBuilder.Options);
        }
    }
}
