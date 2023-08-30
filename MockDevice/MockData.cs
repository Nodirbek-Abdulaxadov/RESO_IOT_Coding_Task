using Core.Models;

namespace MockDevice;

public static class MockData
{
    public static AddTelemetryViewModel GetMockTelemetry()
    {
        Random random = new Random();
        double randomIlluminance = random.Next(100, 500);
        randomIlluminance /= 2;
        long time = (long)DateTime.UtcNow
            .Subtract(DateTime.UnixEpoch).TotalSeconds;
        return new AddTelemetryViewModel()
        {
            illum = randomIlluminance,
            time = time,
        };
    }
}