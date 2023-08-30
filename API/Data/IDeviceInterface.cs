using Core.Models;

namespace API.Data;

public interface IDeviceInterface
{
    Task AddTelemetriesAsync(int deviceId, List<AddTelemetryViewModel> telemetryModels);
    Task<IEnumerable<TelemetryViewModel>> GetStatisticsAsync(int deviceId);
}