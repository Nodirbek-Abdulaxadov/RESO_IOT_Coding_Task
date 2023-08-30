using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Telemetry
{
    [Key, Required]
    public Guid Id { get; set; }
    [Required]
    public double illum { get; set; }
    [Required]
    public DateTime time { get; set; }

    //FK
    public int DeviceId { get; set; }
    public Device? Device { get; set; }
}