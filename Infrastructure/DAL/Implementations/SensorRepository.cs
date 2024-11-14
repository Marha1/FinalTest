using FinalTestDomain.Models;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Implementations;

public class SensorRepository : Repository<Sensor>, ISensorRepository
{
    public SensorRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Sensor> GetSensorWithDetailsAsync(Guid sensorId)
    {
        return await _context.Set<Sensor>()
            .Include(s => s.Data) // Подгружаем данные датчика
            .Include(s => s.Building) // Подгружаем здания, к которым привязан датчик
            .FirstOrDefaultAsync(s => s.Id == sensorId);
    }

    public async Task AddSensorWithDataAsync(Sensor sensor)
    {
        await AddWithIncludesAsync(sensor, s => s.Data);
    }

    public async Task<bool> UpdateSensorWithDataAsync(Sensor sensor)
    {
      return await UpdateWithIncludesAsync(sensor, s => s.Data);
    }
}