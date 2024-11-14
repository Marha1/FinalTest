using FinalTestDomain.Models;

namespace Infrastructure.DAL.Interfaces;

public interface ISensorRepository : IRepository<Sensor>
{
    Task<Sensor> GetSensorWithDetailsAsync(Guid sensorId);
    Task AddSensorWithDataAsync(Sensor sensor);
    Task<bool> UpdateSensorWithDataAsync(Sensor sensor);
}