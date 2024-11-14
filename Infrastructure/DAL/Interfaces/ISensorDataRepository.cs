using FinalTestDomain.Models;

namespace Infrastructure.DAL.Interfaces;

public interface ISensorDataRepository
{
    Task<SensorData> AddAsync(SensorData sensorData);
    Task<SensorData> GetByIdAsync(Guid id);
    Task<IEnumerable<SensorData>> GetAllAsync();
    Task<bool> UpdateAsync(SensorData sensorData);
    Task<bool> DeleteAsync(Guid id);
}