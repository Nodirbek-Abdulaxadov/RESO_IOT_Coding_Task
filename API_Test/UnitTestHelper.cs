using API.Data;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Test;

internal class UnitTestHelper
{
    public static DbContextOptions<AppDbContext> GetUnitTestDbOptions()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using (var context = new AppDbContext(options))
        {
            SeedData(context);
        }

        return options;
    }

    private static void SeedData(AppDbContext context)
    {
        context.Devices.Add(new Device()
        {
            Id = 1,
            Name = "TestName"
        });
        context.SaveChanges();
    }
}