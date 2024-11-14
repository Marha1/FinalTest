using Application.Dtos;
using AutoMapper;
using FinalTestDomain.Models;
using FluentValidation;
using Infrastructure.DAL.Interfaces;

namespace Application.Service;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<User> _validator;

    public UserService(IUserRepository userRepository, IMapper mapper, IValidator<User> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await _validator.ValidateAndThrowAsync(user);
        user = await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return _mapper.Map<UserDto>(user);
    }

    public async Task UpdateUserAsync(Guid userId, UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.Id = userId;
        await _validator.ValidateAndThrowAsync(user);
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        await _userRepository.DeleteAsync(userId);
    }
}