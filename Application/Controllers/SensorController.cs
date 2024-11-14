using Application.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly SensorService _sensorService;

    public SensorController(SensorService sensorService)
    {
        _sensorService = sensorService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterSensor(SensorDto sensorDto)
    {
        var sensor = await _sensorService.CreateSensorAsync(sensorDto);
        return CreatedAtAction(nameof(GetSensorById), new { id = sensor.Id }, sensor);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSensorById(Guid id)
    {
        var sensor = await _sensorService.GetSensorByIdAsync(id);
        if (sensor == null)
            return NotFound();
        return Ok(sensor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSensor(Guid id, SensorDto sensorDto)
    {
        var updatedSensor = await _sensorService.UpdateSensorAsync(id, sensorDto);
        if (updatedSensor is false)
            return NotFound();
        return Ok(updatedSensor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSensor(Guid id)
    {
        await _sensorService.DeleteSensorAsync(id);
        return NoContent();
    }
}