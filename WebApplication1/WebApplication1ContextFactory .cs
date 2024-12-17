using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication1.Areas.Identity.Data
{
    public class WebApplication1ContextFactory : IDesignTimeDbContextFactory<WebApplication1Context>
    {
        public WebApplication1Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<WebApplication1Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new WebApplication1Context(optionsBuilder.Options);
        }
    }
}
