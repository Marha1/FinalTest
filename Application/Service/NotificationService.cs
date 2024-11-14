using Application.Dtos;
using AutoMapper;
using FinalTestDomain.Models;
using FluentValidation;
using Infrastructure.DAL.Interfaces;

namespace Application.Service;

public class NotificationService
{
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;
    private readonly IValidator<Notification> _validator;

    public NotificationService(INotificationRepository notificationRepository, IMapper mapper,
        IValidator<Notification> validator)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<NotificationDto> CreateNotificationAsync(NotificationDto notificationDto)
    {
        var notification = _mapper.Map<Notification>(notificationDto);
        await _validator.ValidateAndThrowAsync(notification);
        notification = await _notificationRepository.AddAsync(notification);
        return _mapper.Map<NotificationDto>(notification);
    }

    public async Task<NotificationDto> GetNotificationByIdAsync(Guid notificationId)
    {
        var notification = await _notificationRepository.GetByIdAsync(notificationId);
        return _mapper.Map<NotificationDto>(notification);
    }
}