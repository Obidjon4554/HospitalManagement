using HospitalManagement.DataAccess;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class HospitalContextFactory : IDesignTimeDbContextFactory<HospitalContext>
{
    public HospitalContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // this is crucial
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<HospitalContext>();
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        return new HospitalContext(optionsBuilder.Options);
    }
}
