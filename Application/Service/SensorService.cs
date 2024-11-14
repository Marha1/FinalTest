using Application.Dtos;
using AutoMapper;
using FinalTestDomain.Models;
using FluentValidation;
using Infrastructure.DAL.Interfaces;

namespace Application.Service;

public class SensorService
{
    private readonly IMapper _mapper;
    private readonly ISensorRepository _sensorRepository;
    private readonly IValidator<Sensor> _validator;

    public SensorService(ISensorRepository sensorRepository, IMapper mapper, IValidator<Sensor> validator)
    {
        _sensorRepository = sensorRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<SensorDto> CreateSensorAsync(SensorDto sensorDto)
    {
        var sensor = _mapper.Map<Sensor>(sensorDto);
        await _validator.ValidateAndThrowAsync(sensor);
        sensor = await _sensorRepository.AddAsync(sensor);
        return _mapper.Map<SensorDto>(sensor);
    }

    public async Task<SensorDto> GetSensorByIdAsync(Guid sensorId)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorId);
        return _mapper.Map<SensorDto>(sensor);
    }

    public async Task<bool> UpdateSensorAsync(Guid sensorId, SensorDto sensorDto)
    {
        try
        {
            var sensor = _mapper.Map<Sensor>(sensorDto);
            sensor.Id = sensorId;
            await _validator.ValidateAndThrowAsync(sensor);
            await _sensorRepository.UpdateAsync(sensor);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task DeleteSensorAsync(Guid sensorId)
    {
        await _sensorRepository.DeleteAsync(sensorId);
    }
}