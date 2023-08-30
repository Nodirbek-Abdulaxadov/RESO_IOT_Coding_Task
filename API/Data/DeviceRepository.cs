using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DeviceRepository : IDeviceInterface
    {
        private readonly AppDbContext _dbContext;

        public DeviceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTelemetriesAsync(int deviceId, 
            List<AddTelemetryViewModel> telemetryModels)
        {
            await _dbContext.Telemetries
                .AddRangeAsync(telemetryModels.Select(i => 
                new Telemetry()
                {
                    Id = Guid.NewGuid(),
                    illum = i.illum,
                    time = i.time.ToDateTime(),
                    DeviceId = deviceId
                }));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TelemetryViewModel>> GetStatisticsAsync(int deviceId)
        {
            var telemetries = await _dbContext.Telemetries
                .Where(t => t.DeviceId == deviceId)
                .OrderByDescending(i => i.time)
                .GroupBy(t => new DateOnly(t.time.Year, t.time.Month, t.time.Day))
                .Take(30)
                .Select(g => new TelemetryViewModel()
                {
                    date = g.First()
                            .time
                            .ToString()
                            .Split()
                            .First(),
                    maxIlluminance = g.Max(i => i.illum)
                })
                .ToListAsync();

            return telemetries;

        }
    }
}
