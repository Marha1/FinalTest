using FinalTestDomain.Models;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Implementations
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly ApplicationContext _context;

        public SensorDataRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SensorData> AddAsync(SensorData sensorData)
        {
            await _context.SensorData.AddAsync(sensorData);
            await _context.SaveChangesAsync();
            return sensorData;
        }

        public async Task<SensorData> GetByIdAsync(Guid id)
        {
            return await _context.SensorData.FindAsync(id);
        }

        public async Task<IEnumerable<SensorData>> GetAllAsync()
        {
            return await _context.SensorData.ToListAsync();
        }

        public async Task<bool> UpdateAsync(SensorData sensorData)
        {
            try
            {
                _context.SensorData.Update(sensorData);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);
            if (sensorData != null)
            {
                _context.SensorData.Remove(sensorData);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}