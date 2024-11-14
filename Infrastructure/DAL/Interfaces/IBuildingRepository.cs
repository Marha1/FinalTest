using FinalTestDomain.Models;

namespace Infrastructure.DAL.Interfaces;

public interface IBuildingRepository : IRepository<Building>
{
    Task<Building> GetBuildingWithDetailsAsync(Guid buildingId);
    Task AddBuildingWithSensorsAsync(Building building);
    Task UpdateBuildingWithSensorsAsync(Building building);
}