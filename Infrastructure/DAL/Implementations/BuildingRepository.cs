using FinalTestDomain.Models;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Implementations;

public class BuildingRepository : Repository<Building>, IBuildingRepository
{
    protected readonly ApplicationContext _context;
    public BuildingRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Building> GetBuildingWithDetailsAsync(Guid buildingId)
    {
        return await _context.Set<Building>()
            .Include(b => b.Sensors)
            .ThenInclude(s => s.Data)
            .FirstOrDefaultAsync(b => b.Id == buildingId);
    }

    public async Task AddBuildingWithSensorsAsync(Building building)
    {
        await AddWithIncludesAsync(building, b => b.Sensors);
    }

    public async Task UpdateBuildingWithSensorsAsync(Building building)
    {
        await UpdateWithIncludesAsync(building, b => b.Sensors);
    }
    
}