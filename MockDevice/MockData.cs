using Core.Models;

namespace MockDevice;

public static class MockData
{
    public static AddTelemetryViewModel GetMockTelemetry()
    {
        Random random = new Random();
        double randomIlluminance = random.Next(100, 400);
        randomIlluminance /= 2;
        long time = (long)DateTime.UtcNow
            .Subtract(DateTime.UnixEpoch).TotalSeconds;
        return new AddTelemetryViewModel()
        {
            illum = randomIlluminance,
            time = time,
        };
    }

    public static List<Telemetry> GetMockTelemetriesList(int deviceId)
    {
        List<Telemetry> list = new();
        for (int i = 0; i < 50; i++)
        {
            var date = DateTime.Now.AddDays(-50);
            for (int j = 0; j < 96; j++)
            {
                Random random = new Random();
                double randomIlluminance = random.Next(100, 400);
                randomIlluminance /= 2;
                list.Add(new Telemetry()
                {
                    Id = Guid.NewGuid(),
                    DeviceId = deviceId,
                    illum = randomIlluminance,
                    time = date.AddDays(i)
                });
            }
        }

        return list;
    }
}