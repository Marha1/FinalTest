using Application.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorDataController : ControllerBase
{
    private readonly SensorDataService _sensorDataService;

    public SensorDataController(SensorDataService sensorDataService)
    {
        _sensorDataService = sensorDataService;
    }

    [HttpPost]
    public async Task<IActionResult> AddSensorData(SensorDataDto sensorDataDto)
    {
        var sensorData = await _sensorDataService.CreateSensorDataAsync(sensorDataDto);
        return CreatedAtAction(nameof(GetSensorData), new { id = sensorData.Id }, sensorData);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSensorData(Guid id)
    {
        var sensorData = await _sensorDataService.GetSensorDataByIdAsync(id);
        if (sensorData == null)
            return NotFound();
        return Ok(sensorData);
    }
}