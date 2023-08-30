using API.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/devices")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IDeviceInterface _deviceInterface;

    public DeviceController(IDeviceInterface deviceInterface)
    {
        _deviceInterface = deviceInterface;
    }

    [HttpPost("{deviceId}/telemetry")]
    public async Task<IActionResult> Post(int deviceId, 
        [FromBody] List<AddTelemetryViewModel> telemetries)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _deviceInterface.AddTelemetriesAsync(deviceId, telemetries);
                return Ok();
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{deviceId}/statistics")]
    public async Task<IActionResult> Get(int deviceId)
    {
        var list = await _deviceInterface.GetStatisticsAsync(deviceId);
        return Ok(list);
    }
}
