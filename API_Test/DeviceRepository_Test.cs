using API.Data;
using Core.Models;
using MockDevice;

namespace API_Test;

internal class DeviceRepository_Test
{
    [Test]
    public async Task AddTelemetriesAsync_AddTelemetries()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());

        var deviceRepository = new DeviceRepository(context);
        await deviceRepository.AddTelemetriesAsync(1, new List<AddTelemetryViewModel>()
        {
            MockData.GetMockTelemetry()
        });
        await context.SaveChangesAsync();

        Assert.That(context.Telemetries.Count(), Is.EqualTo(1));
    }
}