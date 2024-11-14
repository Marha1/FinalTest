using Application.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingController : ControllerBase
{
    private readonly BuildingService _buildingService;

    public BuildingController(BuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBuilding(BuildingDto buildingDto)
    {
        var building = await _buildingService.CreateBuildingAsync (buildingDto);
        return CreatedAtAction(nameof(GetBuildingById), new { id = building.Id }, building);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBuildingById(Guid id)
    {
        var building = await _buildingService.GetBuildingByIdAsync(id);
        if (building == null)
            return NotFound();
        return Ok(building);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBuilding(Guid id, BuildingDto buildingDto)
    {
        var updatedBuilding = await _buildingService.UpdateBuildingAsync(id, buildingDto);
        if (updatedBuilding == null)
            return NotFound();
        return Ok(updatedBuilding);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBuilding(Guid id)
    {
        await _buildingService.DeleteBuildingAsync(id);
        return NoContent();
    }
}