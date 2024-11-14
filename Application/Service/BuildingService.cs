using Application.Dtos;
using AutoMapper;
using FinalTestDomain.Models;
using FluentValidation;
using Infrastructure.DAL.Interfaces;

namespace Application.Service;

public class BuildingService
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Building> _validator;
    private readonly IUserRepository _userRepository;

    public BuildingService(IBuildingRepository buildingRepository, IMapper mapper, IValidator<Building> validator,IUserRepository userRepository)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
        _validator = validator;
        _userRepository = userRepository;
    }

    public async Task<BuildingDto> CreateBuildingAsync(BuildingDto buildingDto)
    {
        // Получаем список пользователей по UserIds
        var users = await _userRepository.FindUsersByIdsAsync(buildingDto.UserIds);
        if (users == null || !users.Any())
        {
            throw new Exception("Users not found");
        }

        // Преобразуем DTO в модель
        var building = _mapper.Map<Building>(buildingDto);

        // Добавляем связь многие ко многим между зданием и пользователями
        foreach (var user in users)
        {
            building.Users.Add(user);
        }

        // Валидируем здание
        await _validator.ValidateAndThrowAsync(building);

        // Добавляем здание в базу данных
        building = await _buildingRepository.AddAsync(building);

        // Возвращаем DTO здания
        return _mapper.Map<BuildingDto>(building);
    }

    public async Task<BuildingDto> GetBuildingByIdAsync(Guid buildingId)
    {
        var building = await _buildingRepository.GetByIdAsync(buildingId);
        return _mapper.Map<BuildingDto>(building);
    }

    public async Task<bool> UpdateBuildingAsync(Guid buildingId, BuildingDto buildingDto)
    {
        try
        {
            var building = _mapper.Map<Building>(buildingDto);
            building.Id = buildingId;
            await _validator.ValidateAndThrowAsync(building);
            await _buildingRepository.UpdateAsync(building);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteBuildingAsync(Guid buildingId)
    {
        await _buildingRepository.DeleteAsync(buildingId);
    }
}