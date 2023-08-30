namespace Core.Models;

public class TelemetryViewModel
{
    public double maxIlluminance { get; set; }
    public string date { get; set; } = string.Empty;

    public static implicit operator TelemetryViewModel(Telemetry telemetry)
        => new TelemetryViewModel()
        {
            maxIlluminance = telemetry.illum,
            date = telemetry.time.ToString()
                                 .Split()
                                 .First()
        };
}