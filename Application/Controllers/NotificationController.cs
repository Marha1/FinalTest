using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly NotificationService _notificationService;

    public NotificationController(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetNotifications(Guid userId)
    {
        var notifications = await _notificationService.GetNotificationByIdAsync(userId);
        return Ok(notifications);
    }
}