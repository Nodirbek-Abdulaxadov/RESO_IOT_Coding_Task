using Core.Models;
using Microsoft.Extensions.Hosting;
using MockDevice;
using Newtonsoft.Json;

namespace App;

public class Worker : BackgroundService
{
    private readonly IService _service;
    List<AddTelemetryViewModel> telemetries = new();

    public Worker(IService service)
    {
        _service = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var item = MockData.GetMockTelemetry();
            telemetries.Add(item);

            if (telemetries.Count >= 4)
            {
                await _service.PostAsync(telemetries);
                telemetries.Clear();
            }

            await Task.Delay(new TimeSpan(0, 0, 1), stoppingToken);
        }
    }
}