using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Device
{
    [Key, Required]
    public int Id { get; set; }
    [StringLength(100), Required]
    public string Name { get; set; } = string.Empty;

    public List<Telemetry> Telemetries = new();
}