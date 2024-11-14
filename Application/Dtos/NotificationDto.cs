namespace Application.Dtos;

public class NotificationDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; }
}