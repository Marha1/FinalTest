using Application.Dtos;
using AutoMapper;
using FinalTestDomain.Models;
using FluentValidation;
using Infrastructure.DAL.Interfaces;

namespace Application.Service;

public class SensorDataService
{
    private readonly IMapper _mapper;
    private readonly ISensorDataRepository _sensorDataRepository;
    private readonly IValidator<SensorData> _validator;

    public SensorDataService(ISensorDataRepository sensorDataRepository, IMapper mapper,
        IValidator<SensorData> validator)
    {
        _sensorDataRepository = sensorDataRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<SensorDataDto> CreateSensorDataAsync(SensorDataDto sensorDataDto)
    {
        var sensorData = _mapper.Map<SensorData>(sensorDataDto);
        await _validator.ValidateAndThrowAsync(sensorData);
        sensorData = await _sensorDataRepository.AddAsync(sensorData);
        return _mapper.Map<SensorDataDto>(sensorData);
    }

    public async Task<SensorDataDto> GetSensorDataByIdAsync(Guid sensorDataId)
    {
        var sensorData = await _sensorDataRepository.GetByIdAsync(sensorDataId);
        return _mapper.Map<SensorDataDto>(sensorData);
    }
}